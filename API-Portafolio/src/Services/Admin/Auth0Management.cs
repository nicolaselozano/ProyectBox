using System.Text;

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

                string token = await Auth0Utilities.GetToken(configuration);

                string userIdAuth0 = await Auth0Utilities.GetUserIdAuth0(token,email);

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
    }
    
}
