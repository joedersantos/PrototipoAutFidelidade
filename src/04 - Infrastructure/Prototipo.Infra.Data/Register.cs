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
       
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            var conn = configuration.GetSection("ConnectionStrings").GetValue<string>("MysqlDb");

            services.AddDbContextPool<FidelidadeContext>(options => options.UseMySQL(conn));

            return services;
        }
    }
}
