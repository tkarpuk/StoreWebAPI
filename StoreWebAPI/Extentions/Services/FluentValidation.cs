using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StoreWebAPI.Behaviours;

namespace StoreWebAPI.Extentions.Services
{
    public static class FluentValidation
    {
        public static void AddFluentValidationExt(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
