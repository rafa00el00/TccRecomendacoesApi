using Microsoft.Extensions.DependencyInjection;
using TCCApi.FachadeApi.Negocio;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Services.Recomendacao;

namespace TCCApi.FachadeApi.Utils
{
    public class IocFactory
    {

        public void Initialize(IServiceCollection services)
        {
            InitializeNegocio(services);
            InitializeServices(services);
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IEventoNegocio, EventoNegocio>();    
        }

        private void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<IEventoCrudService, EventoCrudService>();
            services.AddScoped<IEventoRecomendacaoService, EventoRecomendacaoService>();
            services.AddScoped<ITextoRecomendacaoService, TextoRecomendacaoService>();
        }

    }
}
