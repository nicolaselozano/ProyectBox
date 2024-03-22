

using Microsoft.AspNetCore.Mvc.Filters;

public class CheckUser : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}