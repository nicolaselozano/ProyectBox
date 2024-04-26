using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

public class TokenValidationMiddleware : Attribute,IAsyncAuthorizationFilter
{

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
        {
            string token = authorizationHeader.Substring("Bearer ".Length).Trim();
    
            await ValidateTokenAsync(token);

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

            context.HttpContext.Items.Add("tokendata",jwtToken);

        }
    }


    private Task<TokenValidationResult> ValidateTokenAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Console.WriteLine($"SOY EL TOKEN {token}");
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "https://dev-v2roygalmy6qyix2.us.auth0.com/", 
                ValidateAudience = true,
                ValidAudience = "https://PORTAFOLIO_API.com",
                ValidateLifetime = true
            };

            TokenValidationResult claimsPrincipal = tokenHandler.ValidateTokenAsync(token, validationParameters).Result;
            return Task.FromResult(claimsPrincipal);
        }
        catch (Exception ex)
        {
            throw new Exception("error al comprobar el token");
        }
    }
}
