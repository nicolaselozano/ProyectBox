using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.AspNetCore.Mvc.Filters;

public class GetTokenAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string audience = Environment.GetEnvironmentVariable("AUDIENCE");
            string code = context.HttpContext.Request.Query["code"];

            var client = new RestClient("https://dev-v2roygalmy6qyix2.us.auth0.com/oauth/token");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", $"{clientId}");
            request.AddParameter("client_secret", $"{clientSecret}");
            request.AddParameter("code", $"{code}");
            request.AddParameter("redirect_uri", "http://localhost:3000/callback");
            
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonResponse = response.Content;
                JObject responseObject = JObject.Parse(jsonResponse);
                var accessToken = responseObject["access_token"];

                if (accessToken != null)
                {
                    string token = accessToken.ToString();
                    Console.WriteLine(token);
                    context.HttpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                    return; 
                }
            }

            context.Result = new UnauthorizedResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            context.Result = new UnauthorizedResult();
        }
    }
}    