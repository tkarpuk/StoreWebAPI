﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace StoreWebAPI.Extentions.App
{
    public static class UseSwagger
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
