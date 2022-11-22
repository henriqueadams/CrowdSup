using CrowdSup.Domain.DomainServices.Hash;
using CrowdSup.Domain.DomainServices.Token;
using CrowdSup.Domain.Interfaces.DomainServices.Hash;
using CrowdSup.Domain.Interfaces.DomainServices.Token;
using CrowdSup.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CrowdSup.Infra.Data.repositories.usuarios;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;

namespace CrowdSup.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Domain Services
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IHashService, HashService>();

            // Repositories
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            // Database Contexts
            services.AddDbContext<CrowdsupContext>(options => 
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
            });
        }
    }
}