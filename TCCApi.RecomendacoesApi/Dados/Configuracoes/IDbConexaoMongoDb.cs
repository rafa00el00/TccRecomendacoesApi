using MongoDB.Driver;

namespace TCCApi.RecomendacoesApi.Dados.Configuracoes
{
    public interface IDbConexaoMongoDb: IDbConexao<IMongoClient>
    {

    }
}
