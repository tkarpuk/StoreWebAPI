using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
