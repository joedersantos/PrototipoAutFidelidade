using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.App.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo.App
{
    public static class Register
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            //services.AddDomainDependencies();

            return services;
        }
    }
}
