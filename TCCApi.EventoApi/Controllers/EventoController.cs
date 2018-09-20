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
        private readonly IEventoNegocio _eventoNegocio;

        public EventoController(IEventoNegocio eventoNegocio) : base(eventoNegocio)
        {
            this._eventoNegocio = eventoNegocio;
        }

        [Route("Tags")]
        public IActionResult GetAllTags()
        {
            return Ok(_eventoNegocio.GetAllTags());
        }

        [Route("Empresa/{codEmpresa}")]
        public IActionResult GetEmpresa([FromRoute]int codEmpresa)
        {
            return Ok(_eventoNegocio.GetEmpresaAsync(codEmpresa));
        }




    }
}