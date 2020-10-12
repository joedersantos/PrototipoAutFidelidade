using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.App.Service;
using Prototipo.Domain.Commands;
using Prototipo.Infra.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Prototipo.App
{
    public static class Register
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddMediatR(Assembly.GetAssembly(typeof(CriarUsuarioCommand)));
            services.AddMediatR(Assembly.GetAssembly(typeof(LoginCommand)));
            

            services.AddInfra(configuration);
            return services;
        }
    }
}
