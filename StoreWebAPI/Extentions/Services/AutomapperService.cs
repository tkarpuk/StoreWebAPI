using Microsoft.Extensions.DependencyInjection;

namespace StoreWebAPI.Extentions.Services
{
    public static class AutomapperService
    {
        public static void AddAutomapperExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
