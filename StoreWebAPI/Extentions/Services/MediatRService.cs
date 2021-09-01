using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace StoreWebAPI.Extentions.Services
{
    public static class MediatRService
    {
        public static void AddMediatRExt(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }
    }
}
