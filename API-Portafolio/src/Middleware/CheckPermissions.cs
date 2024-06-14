
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using ApplicationDb.Models;
using Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Web;
using System.Net.Http.Headers;

//lA PERMISSION ES CHEQUEADA POR API SEGUN EL tokenTimeCheck ESPECIFICADO
public class CheckPermissionM(string customPermission = null,int tokenTimeCheck = 10):Attribute,IAsyncAuthorizationFilter
{

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

        try
        {   
            var auth = configuration.GetSection("AUTH");
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                
                foreach (var claim in jwtToken.Claims)
                {
                    Console.WriteLine($"AAAA{claim.Type}: {claim.Value}");
                }   
                
                var idAuth0 = jwtToken.Claims.FirstOrDefault(r => r.Type == "sub").Value.Replace("|","%7C");
                
                Console.WriteLine($"AAAUSER ID {idAuth0}");

                if(idAuth0 == null)
                {
                    throw new Exception("No se proporciono los datos de token para chequear la permission");
                }

                var dbContext = context.HttpContext.RequestServices.GetService<ApplicationDbContext>();
                bool InDatabase = await CheckPermissionsDB(dbContext,idAuth0,customPermission);
                //revisando hace cuanto se hizo la primera solicitud y si vencio el tiempo para reveer el token
                if(RequestUtilities.FirstRequestTime(context,tokenTimeCheck) && InDatabase)
                {
                    Console.WriteLine($"chequeando por DB {customPermission} ; {idAuth0}");
                

                    if(InDatabase)
                    {  
                        Console.WriteLine("La permision del usuario se comprobo en la db");
                        return;
                    }
                }
                else
                {

                    Console.WriteLine("SE ESTA COMPROBANDO POR API");
                    string tokenApi = await Auth0Utilities.GetToken(configuration);

                
                    idAuth0 = idAuth0.Replace("|","%7C");
                    Console.WriteLine("id " + idAuth0);
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/users/{idAuth0}/permissions");
                    request.Headers.Add("Accept", "application/json");
                    request.Headers.Add("Authorization", $"Bearer {tokenApi}");
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var permissions = JArray.Parse(jsonResponse);

                    bool permissionExists = false;

                    foreach (var permission in permissions)
                    {
                        if (permission["permission_name"].ToString() == customPermission)
                        {
                            permissionExists = true;
                            break;
                        }
                    }

                    if (!permissionExists) throw new Exception("No esta autorizado");
                    else 
                    {
                        Console.WriteLine($"{customPermission} {idAuth0}");
                        User user = await dbContext.Users.FirstOrDefaultAsync(u => u.AuthId == idAuth0);
                        
                        user.Rol = customPermission;
                        
                        dbContext.SaveChanges();
                    }
                    Console.WriteLine($"La permisión '{customPermission}' está presente en la respuesta.");
                    return;
                    
                }

            }   
            context.Result = new UnauthorizedResult();
        }
        catch (System.Exception)
        {
            context.Result = new UnauthorizedResult();
            throw;
        }
    }
    private async Task<bool> CheckPermissionsDB(ApplicationDbContext dbContext,string idAuth0,string permission)
    {
        try
        {
            User user = await dbContext.Users.FirstOrDefaultAsync(u => u.AuthId == idAuth0);
            
            if (user == null)
            {
                return false;
            }

            if(user.Rol.ToString() == permission.ToString())
            {
                return true;
            }
            
            return false;

        }
        catch (System.Exception)
        {
            Console.WriteLine("Error al check de permisiones en la db");
            throw;
        }
    }

}