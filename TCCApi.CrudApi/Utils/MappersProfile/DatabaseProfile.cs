using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Util.MappersProfile
{
    public class DatabaseProfile : Profile
    {
        public DatabaseProfile()
        {
            CreateMap<string, EventoTagDTO>()
                .ConstructUsing(str => new EventoTagDTO { TagName = str });
            CreateMap<Evento, EventoDTO>()
                .ForMember(d => d.IdEmpresa, src => src.MapFrom(s => s.Empresa.Id));
        }
    }
}
