using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCCApi.EventoApi.Dados;
using TCCApi.EventoApi.Negocio;

namespace TCCApi.EventoApi.Utils
{
    public class IocFactory
    {

        public void Initialize(IServiceCollection services)
        {
            InitializeDB(services);
            InitializeNegocio(services);
        }

        private void InitializeDB(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
            services.AddScoped<DbContext, MyDbContext>();
            services.AddScoped<IEventoDados, EventoDados>();
            
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IEventoNegocio, EventoNegocio>();
            
        }

    }
}
