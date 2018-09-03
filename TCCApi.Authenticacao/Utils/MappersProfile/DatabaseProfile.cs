using AutoMapper;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Util.MappersProfile
{
    public class DatabaseProfile : Profile
    {
        public DatabaseProfile()
        {
            CreateMap<string, ClienteTagDTO>()
                .ConstructUsing(str => new ClienteTagDTO { TagName = str });
            CreateMap<ClienteTagDTO, string>()
                .ConstructUsing(str => str.TagName);
            
        }
    }
}
