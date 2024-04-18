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
using Reviews.Services;
using System.Text.Json.Serialization;

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
        services.AddScoped<IReviewServices, ReviewService>();
        services.AddTransient<IAsyncAuthorizationFilter, GetTokenAttribute>();
        services.AddTransient<IAsyncAuthorizationFilter,TokenValidationMiddleware>(); 
        services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
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
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://dev-v2roygalmy6qyix2.us.auth0.com/";
                options.Audience = "https://PORTAFOLIO_API.com";
                options.RequireHttpsMetadata = false; 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = "https://dev-v2roygalmy6qyix2.us.auth0.com/", 
                    ValidateAudience = true,
                    ValidAudience = "https://PORTAFOLIO_API.com",
                    ValidateLifetime = true
                };
            });
        

        services.AddHttpContextAccessor();


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