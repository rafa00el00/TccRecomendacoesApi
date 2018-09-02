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
            services.AddScoped<IEmpresaNegocio, EmpresaNegocio>();
            
        }

        private void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<IEventoCrudService, EventoCrudService>();
            services.AddScoped<IEventoRecomendacaoService, EventoRecomendacaoService>();
            services.AddScoped<ITextoRecomendacaoService, TextoRecomendacaoService>();
            services.AddScoped<IUsuarioRecomendacaoService, UsuarioRecomendacaoService>();
            services.AddScoped<IVisitaService, VisitaService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEventoRecomendacaoPyService, EventoRecomendacaoPyService>();
            
        }

    }
}
