using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MiddlewarePBox;
public class TokenValidationMiddleware : Attribute,IAsyncAuthorizationFilter
{

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            Console.WriteLine($"Authorization header: {authorizationHeader}");
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();
                JwtSecurityToken validate = await ValidateTokenAsync(token,context);

                if (validate == null)
                {
                    Console.WriteLine("GENERANDO UN NUEVO TOKEN CON EL REFRESHTOKEN");

                    var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

                    var RTokenExist = (string)context.HttpContext.Request.Headers["Refresh-Token"];

                    TokenDTO newToken = await TokenRefresh.GetTokenWRT(configuration,RTokenExist);

                    if (newToken != null)
                    {
                        Console.WriteLine($"Token TOKKKKKKKKKEEEEEEEEN DATAAAAAAAAAAAAAAA {newToken.AccessToken}");
                        context.HttpContext.Items.Remove("tokenData");
                        context.HttpContext.Items.Add("tokenData",newToken);
                        context.HttpContext.Request.Headers.Add("Authorization", $"Bearer {newToken.AccessToken}");
                        return;
                    }

                    context.Result = new UnauthorizedResult();


                    return;
                }
                context.HttpContext.Items.Remove("tokenData");
                context.HttpContext.Items.Add("tokenData",new TokenDTO{
                    AccessToken=$"{token}"
                });
                
                return;
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }


    private async Task<JwtSecurityToken> ValidateTokenAsync(string token,AuthorizationFilterContext context)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Console.WriteLine($"SOY EL TOKEN VALIDATETOKENASYNC {token}");
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
            $"https://{configuration.GetSection("AUTH")["DOMAIN"]}/.well-known/openid-configuration",
            new OpenIdConnectConfigurationRetriever(),
            new HttpDocumentRetriever());

            var discoveryDocument = await configurationManager.GetConfigurationAsync();
            var signingKeys = discoveryDocument.SigningKeys;
            Console.WriteLine($"https://{configuration.GetSection("AUTH")["DOMAIN"]}/");
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = $"{configuration.GetSection("AUTH")["DOMAIN"]}",
                ValidateAudience = false,
                ValidAudience = $"{configuration.GetSection("AUTH")["DOMAIN"]}",
                // ValidAudience = $"https://{configuration.GetSection("AUTH")["DOMAIN"]}",
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = signingKeys,
                ValidateLifetime = false
            };

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
            
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken;

        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
