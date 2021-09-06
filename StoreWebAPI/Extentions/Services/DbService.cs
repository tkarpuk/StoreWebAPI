using Microsoft.Extensions.DependencyInjection;
using StoreWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreWebAPI.Extentions.Services
{
    public static class DbService
    {
        public static void AddDbServiceExt(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreDB>(options =>
                options.UseSqlServer(connectionString)); 
        }
    }
}
