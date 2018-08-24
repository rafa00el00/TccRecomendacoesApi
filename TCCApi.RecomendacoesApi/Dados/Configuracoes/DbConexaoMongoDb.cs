using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TCCApi.RecomendacoesApi.Dados.Configuracoes
{

    public class DbConexaoMongoDb : IDbConexaoMongoDb
    {
        private MongoClient _db;

        public DbConexaoMongoDb()
        {
        }

        public IMongoClient GetDbInstance()
        {
            if(_db is null)
            {
                _db = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            }

            return _db;
        }

         
    }
}
