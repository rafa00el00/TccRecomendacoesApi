using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;

namespace TCCApi.RecomendacoesApi.Dados.DadosBrutos
{
    public interface IDbConexaoDadosBrutos
    {

    }

    public class DbConexaoDadosBrutos : DbConexaoDadosAbstract, IDbConexaoDadosBrutos
    {
        public DbConexaoDadosBrutos(IDbConexaoMongoDb dbConexaoMongoDb) : base(dbConexaoMongoDb)
        {
        }

        protected override string DbName => "DadosEventos";
    }
}
