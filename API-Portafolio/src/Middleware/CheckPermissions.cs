
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class CheckPermissionM:Attribute,IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {   
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

                foreach (var claim in jwtToken.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }   

                return;


            }   
            context.Result = new UnauthorizedResult();
        }
        catch (System.Exception)
        {
            context.Result = new UnauthorizedResult();
            throw;
        }
    }
}