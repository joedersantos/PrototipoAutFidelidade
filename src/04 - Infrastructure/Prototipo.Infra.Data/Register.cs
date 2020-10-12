using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prototipo.Domain.Repository;
using Prototipo.Infra.Data.Context;
using Prototipo.Infra.Data.Repository;
using System;

namespace Prototipo.Infra.Data
{
    public static class Register
    {
        private const string CONN_STRING = "Server=db;Port=3306;Database=product-db;Uid=root; Pwd=myPass;";
        //private const string CONN_STRING = "Server=localhost;Port=3306;Database=fidelidade-db;Uid=root; Pwd=myPass;";

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddDbContextPool<FidelidadeContext>(options => options.UseMySQL(CONN_STRING));

            return services;
        }
    }
}
