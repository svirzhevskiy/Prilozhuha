using System.Reflection;
using Application.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped<IPostService, PostService>();
            
            return services;
        }
    }
}