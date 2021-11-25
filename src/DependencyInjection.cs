using Microsoft.Extensions.DependencyInjection;
using RestSharp.Service;

namespace RestSharp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRestServices(this IServiceCollection Services)
        {
            Services.AddTransient<IRestService, RestService>();
            return Services;
        }
    }
}
