using System.Collections.Generic;
using TCCApi.EventoApi.Dados;
using TCCApi.EventoApi.Models;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Negocio
{


    public interface IEventoNegocio: IGenericNegocio<Evento,EventoDTO>
    {
        IList<string> GetAllTags();
    }

    public class EventoNegocio : GenericNegocio<Evento,EventoDTO> , IEventoNegocio
    {
        private readonly IEventoDados _eventoDados;

        public EventoNegocio(IEventoDados eventoDados) : base(eventoDados)
        {
            this._eventoDados = eventoDados;
        }

        public IList<string> GetAllTags()
        {
            return _eventoDados.GetAllTags();
        }
    }

    

    





}
