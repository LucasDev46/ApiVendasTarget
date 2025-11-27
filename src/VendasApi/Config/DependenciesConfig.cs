using VendasBusiness.Interface.Repository;
using VendasBusiness.Interface.Services;
using VendasBusiness.Notificacoes;
using VendasBusiness.Services;
using VendasData.Repository;

namespace VendasApi.Config
{
    public static class DependenciesConfig
    {

        //metodo para resolver dependencias, apenas para deixar a class program mais limpa.
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IVendedorService, VendedorService>();

            return services;

        }
    }
}
