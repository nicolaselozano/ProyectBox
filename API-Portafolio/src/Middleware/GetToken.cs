using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.AspNetCore.Mvc.Filters;
using MiddlewarePBox;

public class GetTokenAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            Console.WriteLine("empezando el getTOKEN");
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

            RefreshTokenDTO refreshToken = await TokenRefresh.GetRToken(context,configuration);

            if (refreshToken != null)
            {
                Console.WriteLine("sacando refresh");
                TokenDTO tokenData = await TokenRefresh.GetTokenWRT(configuration,refreshToken.RefreshToken);
                Console.WriteLine(refreshToken.AccessToken);
                context.HttpContext.Items.Add("refreshTokenData",refreshToken);
                context.HttpContext.Items.Add("tokenData",tokenData);
                context.HttpContext.Request.Headers.Add("Refresh-Token",$"{refreshToken.RefreshToken}");
                context.HttpContext.Request.Headers.Add("Authorization", $"Bearer {refreshToken.AccessToken}");
                return; 
                
            }

            context.Result = new UnauthorizedResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            context.Result = new UnauthorizedResult();
        }
    }
}    