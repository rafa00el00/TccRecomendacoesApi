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
                .ForMember(d => d.Titulo, s => s.MapFrom(src => src.Nome))
                .ForMember(d => d.Local, s => s.MapFrom(scr => $"{scr.Logradouro},{scr.Numero} - {scr.Bairro} - {scr.Cidade}"));
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

                config.CreateMap<Compra, ItemCompra>()
                .ForMember(d => d.Titulo, s => s.MapFrom(c => c.Descricao))
                .ForMember(d => d.CodEvento, s=> s.MapFrom(c=>c.ItemID));
                config.CreateMissingTypeMaps = true;
            });
        }


    }
}
