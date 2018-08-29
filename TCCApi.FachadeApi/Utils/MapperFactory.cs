using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.RecomendacoesApi.Utils
{
    public class MapperFactory
    {
        public MapperFactory()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Evento, ItemEvento>()
                .ForMember(d => d.Titulo, s => s.MapFrom(src => src.Nome));
                config.CreateMissingTypeMaps = true;
            });
        }


    }
}
