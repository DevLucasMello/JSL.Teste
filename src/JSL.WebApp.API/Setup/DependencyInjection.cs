using JSL.Motorista.Data;
using JSL.Motorista.Data.Repository;
using JSL.Motorista.Domain;
using JSL.Viagem.Data;
using JSL.Viagem.Data.Repository;
using JSL.Viagem.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace JSL.WebApp.API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Motorista
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<MotoristaContext>();

            // Viagem
            services.AddScoped<IViagemRepository, ViagemRepository>();
            services.AddScoped<ViagemContext>();

        }
    }
}
