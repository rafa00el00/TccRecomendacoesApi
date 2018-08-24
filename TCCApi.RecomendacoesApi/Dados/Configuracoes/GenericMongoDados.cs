using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;

namespace TCCApi.RecomendacoesApi.Dados.Configuracoes
{
    public interface IGenericMongoDados<T>
    {
        IQueryable<T> GetAll();
    }

    public abstract class GenericMongoDados<T>: IGenericMongoDados<T>
    {
        protected IMongoCollection<T> _dababase { get; }
        protected abstract string DatabaseName { get; }

        public GenericMongoDados(IDbConexaoDadosAbstract dbConexaoDados)
        {
            _dababase = dbConexaoDados.GetDatabase().GetCollection<T>(DatabaseName);
        }

        public IQueryable<T> GetAll()
        {
            return _dababase.AsQueryable<T>();
        }
        
    }
}
