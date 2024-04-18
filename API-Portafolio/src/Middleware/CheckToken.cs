using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

public class TokenValidationMiddleware : Attribute,IAsyncAuthorizationFilter
{

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        {
            string token = authorizationHeader.Substring("Bearer ".Length);

            var validationResult = await ValidateTokenAsync(token);

            var claims = validationResult.Claims;
            if (claims != null)
            {
                var claimList = new List<Claim>();

                var usernameClaim = claims.FirstOrDefault(c => c.Type == "username");
                if (usernameClaim != null)
                {
                    string username = usernameClaim.Value;
                    Console.WriteLine("HOLA SOSOSOSOSO", username);
                    claimList.Add(new Claim(ClaimTypes.Name, username));
                }

                context.HttpContext.User.AddIdentity(new ClaimsIdentity(claimList, "Bearer"));
            }
        }
    }


    private Task<ClaimsPrincipal> ValidateTokenAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "https://dev-v2roygalmy6qyix2.us.auth0.com/", 
                ValidateAudience = true,
                ValidAudience = "https://PORTAFOLIO_API.com",
                ValidateLifetime = true
            };

            // Intenta validar el token
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            
            // Si la validación tiene éxito, devuelve un resultado válido con las reclamaciones del token
            return Task.FromResult(claimsPrincipal);
        }
        catch (Exception ex)
        {
            throw new Exception("error al comprobar el token");
        }
    }
}
