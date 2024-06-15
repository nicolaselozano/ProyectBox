
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePBox
{
    internal class TokenRefresh
    {
        public static async Task<RefreshTokenDTO> GetRToken(AuthorizationFilterContext context,IConfiguration configuration)
        {
            try
            {
                string code = context.HttpContext.Request.Query["code"];
                Console.WriteLine(code);
                var CLIEN_ID = configuration.GetSection("AUTH")["CLIEN_ID"];
                var CLIENT_SECRET = configuration.GetSection("AUTH")["CLIENT_SECRET"];
                var CLIENT_HOST = configuration.GetSection("AUTH")["CLIEN_HOST"];

                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post,"https://dev-v2roygalmy6qyix2.us.auth0.com/oauth/token");

                // request.Headers.Add("content-type", "application/x-www-form-urlencoded");

                // Add form data
                var formData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("client_id", $"{CLIEN_ID}"),
                    new KeyValuePair<string, string>("client_secret", $"{CLIENT_SECRET}"),
                    new KeyValuePair<string, string>("code", $"{code}"),
                    new KeyValuePair<string, string>("redirect_uri", $"{CLIENT_HOST}/pages/redirect"),
                };

                request.Content = new FormUrlEncodedContent(formData);

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();
                
                RefreshTokenDTO refreshToken = await DeserializeRToken(response);
                Console.WriteLine($"ANTES RT {refreshToken.RefreshToken}");
                return refreshToken;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static async Task<RefreshTokenDTO> DeserializeRToken(HttpResponseMessage dataResponse)
        {
            var responseContent = await dataResponse.Content.ReadAsStringAsync();

            var RtokenResponse = System.Text.Json.JsonSerializer.Deserialize<RefreshTokenDTO>(responseContent);

            return RtokenResponse;
        }
        private static async Task<TokenDTO> DeserializeToken(HttpResponseMessage dataResponse)
        {
            var responseContent = await dataResponse.Content.ReadAsStringAsync();

            var RtokenResponse = System.Text.Json.JsonSerializer.Deserialize<TokenDTO>(responseContent);

            return RtokenResponse;
        }
        
        public static async Task<TokenDTO> GetTokenWRT(IConfiguration configuration,string refreshToken)
        {
            try
            {
                var CLIEN_ID = configuration.GetSection("AUTH")["CLIEN_ID"];
                var CLIENT_SECRET = configuration.GetSection("AUTH")["CLIENT_SECRET"];
                var CLIENT_HOST = configuration.GetSection("AUTH")["CLIEN_HOST"];

                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post,"https://dev-v2roygalmy6qyix2.us.auth0.com/oauth/token");

                // Add form data
                var formData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("client_id", $"{CLIEN_ID}"),
                    new KeyValuePair<string, string>("client_secret", $"{CLIENT_SECRET}"),
                    new KeyValuePair<string, string>("refresh_token", $"{refreshToken}"),
                    new KeyValuePair<string, string>("redirect_uri", $"{CLIENT_HOST}/pages/redirect"),
                };

                request.Content = new FormUrlEncodedContent(formData);

                var response = await httpClient.SendAsync(request);
                Console.WriteLine($"Refresh token : {refreshToken}");
                response.EnsureSuccessStatusCode();

                TokenDTO token = await DeserializeToken(response);
                Console.WriteLine($"TOKEN DE RT {token.AccessToken}" );
                return token;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }

}