using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Any;
using NuGet.Protocol;

//USAR ESTE METODO EN EL SERVICIO
namespace  Auth0Management
{
    public interface IRolManagement
    {
        Task<string> SetUserRol(string email,string[] roles);
    }
    public class RolManagment(IConfiguration configuration):IRolManagement
    {
        public async Task<string> SetUserRol(string email, string[] roles)
        {
            try
            {
                if (roles == null)
                {
                    throw new Exception("El rol es nulo");
                }

                string token = await GetToken();

                string userIdAuth0 = await GetUserIdAuth0(token,email);

                bool setRoles = await SetRoleToUser(token,userIdAuth0,roles);

                if (!setRoles)
                {
                    throw new Exception("No se asigno el Rol, fallo al hacer la peticion para asignar el rol");
                }

                return "Rol asignado correctamente";

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        private async Task<bool> SetRoleToUser(string token,string userIdAuth0, string[] roles)
        {
            try
            {
                StringBuilder allRoles = new StringBuilder();

                foreach (var rol in roles)
                {
                    allRoles.Append(rol.ToString());
                }
                
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/users/{userIdAuth0}/roles");

                request.Headers.Add("content-type", "application/json");
                request.Headers.Add("authorization", $"Bearer {token}");
                request.Headers.Add("cache-control", "no-cache");

                request.Content = new StringContent(allRoles.ToString(), Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                return true;

            }
            catch (System.Exception)
            {
                return false;
            }
        }
        private async Task<string> GetUserIdAuth0(string token,string email)
        {
            try
            {
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://dev-v2roygalmy6qyix2.us.auth0.com/api/v2/users-by-email?email={email}");

                request.Headers.Add("Authorization", $"Bearer {token}");

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                var JsonResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);


                string userId = JsonResponse["user_id"].ToString();

                if(userId == null)
                {
                    throw new Exception("no se obtuvo la id correctamente al hacer la peticion a la api");
                }

                return userId;

            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        private async Task<string> GetToken()
        {
            try
            {
                string clientSecret = configuration.GetSection("AUTH")["CLIENT_SECRET"];

                if(clientSecret == null)
                {
                    throw new Exception("No se aporto el client_secret");
                }

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
    
}
