using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Common;

namespace MiddlewarePBox
{
    public class MRefreshToken(IConfiguration configuration):Attribute,IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                if (context.Result == new UnauthorizedResult())
                {
                    var RTokenExist = (string)context.HttpContext.Request.Headers["Refresh-Token"];
                    
                    if(RTokenExist != null)
                    {
                        TokenDTO newToken = await TokenRefresh.GetTokenWRT(configuration, RTokenExist);
                        context.HttpContext.Items.Add("tokenData",newToken);
                        context.Result = null;
                        return;
                    }
                }

                return;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
