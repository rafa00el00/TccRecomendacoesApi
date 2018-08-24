using MongoDB.Driver;

namespace TCCApi.RecomendacoesApi.Dados.Configuracoes
{

    public interface IDbConexaoDadosAbstract
    {
        IMongoDatabase GetDatabase();
    }

    public abstract class DbConexaoDadosAbstract : IDbConexaoDadosAbstract
    {
        private IMongoDatabase _db;
        protected abstract string DbName { get; }

        public DbConexaoDadosAbstract(IDbConexaoMongoDb dbConexaoMongoDb)
        {
            var db = dbConexaoMongoDb.GetDbInstance();
            _db = db.GetDatabase(DbName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _db; 
        }
        
    }
}
