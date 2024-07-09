using ApplicationDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Proyects.Services;
using Users.Services;

using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Reviews.Services;
using System.Threading.RateLimiting;
using Auth0Management;
using Hubs;
using Notification.Services;

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
                        $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s). ", cancellationToken: token);
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync(
                        "Too many requests. Please try again later. ", cancellationToken: token);
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
        services.AddTransient<NClientHubService>();
        services.AddTransient<NAllClientsHubService>();
        services.AddTransient<INotificationStrategy, NClientHubService>();

        

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
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
                    builder.WithOrigins("https://proyectbox-au5d.onrender.com","http://localhost:3000","https://proyectbox.onrender.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
        
        //websocket
        services.AddSignalR();


        //setTokenHub
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/notifications-hub"))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        });

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
            endpoints.MapHub<NotificationsHub>("/notifications-hub");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}