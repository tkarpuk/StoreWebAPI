using Microsoft.AspNetCore.Builder;

namespace StoreWebAPI.Extentions.Configure
{
    public static class SwaggerConfig
    {
        public static void UseSwaggerExt(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
