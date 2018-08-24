using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;

namespace TCCApi.RecomendacoesApi.Dados.DadosRecomendacoes
{
    public interface IDbConexaoDadosRecomendacoes : IDbConexaoDadosAbstract
    {
    }

    public class DbConexaoDadosRecomendacoes : DbConexaoDadosAbstract, IDbConexaoDadosRecomendacoes
    {
        public DbConexaoDadosRecomendacoes(IDbConexaoMongoDb dbConexaoMongoDb) : base(dbConexaoMongoDb)
        {
        }

        protected override string DbName => "RecomendacoesEventos";
    }

}
