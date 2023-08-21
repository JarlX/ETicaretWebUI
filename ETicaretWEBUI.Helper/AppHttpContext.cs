namespace ETicaretWEBUI.Helper;

using Microsoft.AspNetCore.Http;

public class AppHttpContext
{ 
    static IServiceProvider _serviceProvider;

    public static IServiceProvider ServiceProvider
    {
        get { return _serviceProvider; }
        set { _serviceProvider = value; }
    }

    public static HttpContext CurrentContext
    {
        get
        {
            IHttpContextAccessor httpContextAccessor =
                _serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;

            return httpContextAccessor.HttpContext;
        }
    }
    
    
}