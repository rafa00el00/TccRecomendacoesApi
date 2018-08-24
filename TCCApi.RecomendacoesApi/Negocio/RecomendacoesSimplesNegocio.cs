using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Dados.DadosRecomendacoes;
using TCCApi.RecomendacoesApi.Models;
using TCCApi.RecomendacoesApi.Models.DTO;

namespace TCCApi.RecomendacoesApi.Negocio
{
   
    public interface IRecomendacoesSimplesNegocio : IGenericNegocio<RecomendacaoSimples,RecomendacoesSimplesTO>
    {
        RecomendacaoSimples Get(string key);
    }

    public class RecomendacoesSimplesNegocio : GenericNegocio<RecomendacaoSimples, RecomendacoesSimplesTO>, IRecomendacoesSimplesNegocio
    {
        private IRecomendacoesEventosDados dados;
        public RecomendacoesSimplesNegocio(IRecomendacoesEventosDados db) : base(db)
        {
            dados = db;
        }

        public RecomendacaoSimples Get(string key)
        {
            return  GetAll().FirstOrDefault(x => x.Codigo.Equals(key)); 
        }
    }
}
