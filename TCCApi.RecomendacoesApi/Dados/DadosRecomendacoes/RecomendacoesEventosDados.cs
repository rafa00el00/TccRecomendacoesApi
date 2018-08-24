using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;
using TCCApi.RecomendacoesApi.Dados.DadosBrutos;
using TCCApi.RecomendacoesApi.Models;
using TCCApi.RecomendacoesApi.Models.DTO;

namespace TCCApi.RecomendacoesApi.Dados.DadosRecomendacoes
{

    public interface IRecomendacoesEventosDados : IGenericMongoDados<RecomendacoesSimplesTO>
    {
        RecomendacoesSimplesTO Get(string key);
    }

    public class RecomendacoesEventosDados : GenericMongoDados<RecomendacoesSimplesTO>, IRecomendacoesEventosDados
    {
        public RecomendacoesEventosDados(IDbConexaoDadosRecomendacoes dbConexaoDados) : base(dbConexaoDados)
        {
        }

        protected override string DatabaseName => "eventos";

        public RecomendacoesSimplesTO Get(string key)
        {
            return GetAll().FirstOrDefault(x => x.Dados.Names.Contains(key));
        }
    }
}
