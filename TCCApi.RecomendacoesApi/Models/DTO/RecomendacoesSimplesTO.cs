using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.RecomendacoesApi.Models.DTO
{
    public class RecomendacoesSimplesTO
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonExtraElements]
        public BsonDocument Dados { get; set; }
    }
}
