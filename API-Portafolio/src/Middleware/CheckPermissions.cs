
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json;

public class CheckPermissionM:Attribute,IAsyncAuthorizationFilter
{

    private readonly string _customPermission;
    public CheckPermissionM(string customPermission = null)
    {
        _customPermission = customPermission;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

        try
        {   
            var auth = configuration.GetSection("AUTH");
            Console.WriteLine("el TOOOOOOOOKENBSSS " + auth["CLIENT_SECRET"].ToString());
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                
                foreach (var claim in jwtToken.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value} hOLIS");
                }   
                
                var userId = Uri.EscapeDataString(jwtToken.Claims.FirstOrDefault(r => r.Type == "sub").Value);

                Console.WriteLine($"USER ID {userId}");
                
                string tokenApi = await GetToken(auth["CLIENT_SECRET"].ToString());

                Console.WriteLine("WOW");

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/users/{userId}/permissions");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {tokenApi}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var permissions = JArray.Parse(jsonResponse);

                bool permissionExists = false;

                foreach (var permission in permissions)
                {
                    if (permission["permission_name"].ToString() == _customPermission)
                    {
                        permissionExists = true;
                        break;
                    }
                }

                if (!permissionExists) throw new Exception("No esta autorizado");
                Console.WriteLine($"La permisión '{_customPermission}' está presente en la respuesta.");
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

}