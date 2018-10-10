using Microsoft.AspNetCore.Mvc;
using TCCApi.FeedbackApi.Models;
using TCCApi.FeedbackApi.Models.DTO;
using TCCApi.FeedbackApi.Negocio;

namespace TCCApi.FeedbackApi.Controllers
{

    [Produces("application/json")]
    [Route("api/Feedback")]
    public class EventoController : GenericController<Feedback, FeedbackDTO>
    {
        private readonly IFeedbackNegocio _eventoNegocio;

        public EventoController(IFeedbackNegocio eventoNegocio) : base(eventoNegocio)
        {
            this._eventoNegocio = eventoNegocio;
        }

        [Route("Evento/{codEvento}")]
        public IActionResult GetFromEvento(string codEvento)
        {
            var feeds = _eventoNegocio.GetFromEventos(codEvento);
            return Ok(feeds);
        }

    }
}