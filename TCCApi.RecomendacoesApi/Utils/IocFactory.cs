using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Dados;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;
using TCCApi.RecomendacoesApi.Dados.DadosBrutos;
using TCCApi.RecomendacoesApi.Dados.DadosRecomendacoes;
using TCCApi.RecomendacoesApi.Negocio;

namespace TCCApi.RecomendacoesApi.Utils
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
            services.AddSingleton<IDbConexaoMongoDb, DbConexaoMongoDb>();
            services.AddSingleton<IDbConexaoDadosBrutos, DbConexaoDadosBrutos>();
            services.AddSingleton<IDbConexaoDadosRecomendacoes, DbConexaoDadosRecomendacoes>();
            services.AddScoped<IRecomendacoesEventosDados, RecomendacoesEventosDados>();
            
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IRecomendacoesSimplesNegocio, RecomendacoesSimplesNegocio>();    
        }

    }
}
