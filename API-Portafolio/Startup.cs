using ApplicationDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Amazon.S3;
using Proyects.Services;
using Users.Services;

using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;


public class Startup
{

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        Console.WriteLine("Configurando");
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
        
        services.AddControllers();
        services.AddScoped<IProyectService, ProyectService>();
        services.AddScoped<IUserServices, UserService>();
        services.AddTransient<IAsyncAuthorizationFilter, GetTokenAttribute>();

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = null;
        });
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            opt.UseNpgsql(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nombre de tu API", Version = "v1" });
        });

        // CORS CONFIG
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost3000",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }); 
        });
        
        services.AddAuthentication(options =>
        {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
        options.Authority = "https://dev-v2roygalmy6qyix2.us.auth0.com/"; // Replace with your Auth0 domain
        options.Audience = "https://PORTAFOLIO_API.com"; // Replace with your API audience
        });


        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = null;
        });
        // AWS S3
        // services.AddAWSService<IAmazonS3>();



    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        Env.Load();

        app.UseCors("AllowLocalhost3000");

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portafolio .NET"));
        }
        
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}