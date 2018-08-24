using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.RecomendacoesApi.Models;
using TCCApi.RecomendacoesApi.Models.DTO;

namespace TCCApi.RecomendacoesApi.Utils.MappersProfile
{
    public class MongoObjectsProfile : Profile
    {
        public MongoObjectsProfile()
        {
            CreateMap<RecomendacoesSimplesTO, RecomendacaoSimples>()
                .ForMember(d=>d.Codigo, c => c.MapFrom(s=> s.Dados.FirstOrDefault().Name))
                .ForMember(d =>d.Similares, c=> c.MapFrom(s => s.Dados.FirstOrDefault().Value));
        }
    }
}
