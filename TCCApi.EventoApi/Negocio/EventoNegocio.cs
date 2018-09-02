using TCCApi.EventoApi.Dados;
using TCCApi.EventoApi.Models;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Negocio
{


    public interface IEventoNegocio: IGenericNegocio<Evento,EventoDTO>
    {
        
    }

    public class EventoNegocio : GenericNegocio<Evento,EventoDTO> , IEventoNegocio
    {
        

        public EventoNegocio(IEventoDados eventoDados) : base(eventoDados)
        {
            
        }

        
    }

    

    





}
