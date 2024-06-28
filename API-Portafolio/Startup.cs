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
using System.Threading.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Auth0Management;
using Hubs;

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
        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 50,
                    QueueLimit = 0,
                    Window = TimeSpan.FromMinutes(1)
                })
            );

            options.OnRejected = async (context,token) => {
                context.HttpContext.Response.StatusCode = 429;
                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsync(
                        $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s). " +
                        $"Read more about our rate limits at https://example.org/docs/ratelimiting.", cancellationToken: token);
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync(
                        "Too many requests. Please try again later. " +
                        "Read more about our rate limits at https://example.org/docs/ratelimiting.", cancellationToken: token);
                }
            };
        });
        
        services.AddControllers();
        services.AddMemoryCache(); 

        services.AddSingleton<IConfiguration>(Configuration);
        services.AddSingleton<ConnectionMapping>();

        services.AddScoped<IProyectService, ProyectService>();
        services.AddScoped<IUserServices, UserService>();
        services.AddScoped<IUtilitiesReviewServices, UtilitiesReviewServices>();
        services.AddScoped<IReviewServices, ReviewService>();
        services.AddTransient<IAsyncAuthorizationFilter, GetTokenAttribute>();
        services.AddTransient<IAsyncAuthorizationFilter,TokenValidationMiddleware>(); 
        services.AddTransient<IAsyncAuthorizationFilter,CheckPermissionM>();
        services.AddTransient<IRolManagement,RolManagment>();

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
        

        services.AddHttpContextAccessor();


        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = null;
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost3000",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
        
        //websocket
        services.AddSignalR();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        Env.Load();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portafolio .NET"));
        }
        
        app.UseRouting();

        app.UseCors("AllowLocalhost3000");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<NotificationsHub>("/notifications-hub").RequireCors("AllowLocalhost3000");
        });
    }
}