
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using ApplicationDb.Models;
using Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class CheckPermissionM(string customPermission = null,int tokenTimeCheck = 10):Attribute,IAsyncAuthorizationFilter
{

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

        try
        {   
            var auth = configuration.GetSection("AUTH");
            Console.WriteLine("el TOOOOOOOOKENBSSS ");
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
                
                var idAuth0 = Uri.EscapeDataString(jwtToken.Claims.FirstOrDefault(r => r.Type == "sub").Value);
                
                Console.WriteLine($"USER ID {idAuth0}");

                if(idAuth0 == null)
                {
                    throw new Exception("No se proporciono los datos de token para chequear la permission");
                }

                //revisando hace cuanto se hizo la primera solicitud y si vencio el tiempo para reveer el token
                if(await FirstRequestTime(context,tokenTimeCheck))
                {
                    var dbContext = context.HttpContext.RequestServices.GetService<ApplicationDbContext>();

                    bool user = await CheckPermissionsDB(dbContext,idAuth0,customPermission);

                    if(user)
                    {  
                        Console.WriteLine("La permision del usuario se comprobo en la db");
                        return;
                    }
                }
                else
                {

                    Console.WriteLine("SE ESTA COMPROBANDO POR API");
                    string tokenApi = await GetToken(auth["CLIENT_SECRET"].ToString());

                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/users/{idAuth0}/permissions");
                    request.Headers.Add("Accept", "application/json");
                    request.Headers.Add("Authorization", $"Bearer {tokenApi}");
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
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

    private async Task<string> GetToken(string clientSecret)
    {
        try
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://dev-v2roygalmy6qyix2.us.auth0.com/oauth/token");

            // Add form data
            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", "2qH0pL2qNs9XRGJokqg9XnypmZDeEh42"),
                new KeyValuePair<string, string>("client_secret", $"{clientSecret}"),
                new KeyValuePair<string, string>("audience", "https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/")
            };

            request.Content = new FormUrlEncodedContent(formData);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var tokenResponse = System.Text.Json.JsonSerializer.Deserialize<TokenDTO>(responseContent);

            string accessToken = tokenResponse.AccessToken;

            return accessToken;

        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    private async Task<bool> FirstRequestTime(AuthorizationFilterContext context,int time = 10)
    {
        try
        {   
            string cacheKey = "FirstRequestTime";
            var cache = context.HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;
            var FrExist = cache.TryGetValue(cacheKey, out DateTime firstRequest);
            if(!FrExist)
            {
                Console.WriteLine("fr no existe");
                firstRequest = DateTime.Now;
                cache.Set(cacheKey, firstRequest,TimeSpan.FromMinutes(time));
                return false;
            }
            Console.WriteLine($"DIFERENCIA DE TIEMPO ENTRE REQUEST : {DateTime.Now - firstRequest} : {TimeSpan.FromMinutes(time)}");
            if((DateTime.Now - firstRequest) > TimeSpan.FromMinutes(time))
            {
                Console.WriteLine("SE RESETEO EL TOKEN");
                //reset TokenCheck
                return false;
            }else{
                return true;
            }
        }
        catch (System.Exception)
        {
            
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