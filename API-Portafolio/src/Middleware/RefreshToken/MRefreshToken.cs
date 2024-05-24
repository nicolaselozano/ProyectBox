using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePBox
{
    public class MRefreshToken(string customPermission = null,int tokenTimeCheck = 10):Attribute,IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                //IMPLEMENTAR LOS METODOS DE REFRESH TOKEN
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
