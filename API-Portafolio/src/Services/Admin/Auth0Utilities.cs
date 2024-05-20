using System.Text.Json;

internal class Auth0Utilities
{
        public static async Task<string> GetUserIdAuth0(string token,string email)
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
        public static async Task<string> GetToken(IConfiguration configuration)
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