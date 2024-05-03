using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        try
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();
        
                await ValidateTokenAsync(token);

                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

                Console.WriteLine($"Es valido hasta {jwtToken.ValidTo}");

                context.HttpContext.Items.Add("tokendata",jwtToken);

            }
        }
        catch (System.Exception)
        {
            
            throw;
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("xToZmWF6p38T9phy2ISp32DE0tEfSeTUaU2omWSqcfyNjeSLS8VPF5nQCrIph3sF")),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
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
