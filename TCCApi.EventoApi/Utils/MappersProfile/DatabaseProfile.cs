using AutoMapper;
using TCCApi.EventoApi.Models;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Util.MappersProfile
{
    public class DatabaseProfile : Profile
    {
        public DatabaseProfile()
        {
            CreateMap<string, EventoTagDTO>()
                .ConstructUsing(str => new EventoTagDTO { TagName = str });
            CreateMap<EventoTagDTO, string>()
                .ConstructUsing(str => str.TagName);
            
        }
    }
}
