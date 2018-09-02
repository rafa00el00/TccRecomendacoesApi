using Microsoft.AspNetCore.Mvc;
using TCCApi.EventoApi.Models;
using TCCApi.EventoApi.Models.DTO;
using TCCApi.EventoApi.Negocio;

namespace TCCApi.EventoApi.Controllers
{

    [Produces("application/json")]
    [Route("api/Evento")]
    public class EventoController : GenericController<Evento, EventoDTO>
    {
        public EventoController(IEventoNegocio eventoNegocio) : base(eventoNegocio)
        {

        }
    }
}