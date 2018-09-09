using AutoMapper;
using TCCApi.FachadeApi.Model;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Models;

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
                config.CreateMap<Usuario, ApplicationUserTO>()
                    .ConstructUsing(d => new ApplicationUserTO() {
                        Email = d.Email,
                        UserName = d.Email,
                        Password = d.Password,
                        Claims = ApplicationUserTO.CreateClaimsFrom<Usuario>(d)
                    });
                config.CreateMap<Empresa, ApplicationUserTO>()
                    .ConstructUsing(d => new ApplicationUserTO()
                    {
                        Email = d.Email,
                        UserName = d.Email,
                        Password = d.Password,
                        Claims = ApplicationUserTO.CreateClaimsFrom<Empresa>(d)
                    });
                config.CreateMissingTypeMaps = true;
            });
        }


    }
}
