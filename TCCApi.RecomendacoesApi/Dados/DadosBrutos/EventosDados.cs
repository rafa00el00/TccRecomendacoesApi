using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.RecomendacoesApi.Dados.DadosBrutos
{
    public class EventosDados
    {
        private IMongoCollection<dynamic> _dababase;


        public EventosDados(DbConexaoDadosBrutos dbConexaoDadosBrutos)
        {
            _dababase = dbConexaoDadosBrutos.GetDatabase().GetCollection<dynamic>("eventos");

        }


    }

}
