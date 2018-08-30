using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCCApi.FachadeApi.Model;
using TCCApi.FachadeApi.Negocio;
using TCCApi.FachadeApi.ViewModel;

namespace TCCApi.FachadeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Evento")]
    public class EventoController : Controller
    {
        private readonly IEventoNegocio _eventoNegocio;

        public EventoController(IEventoNegocio eventoNegocio)
        {
            this._eventoNegocio = eventoNegocio;
        }

        public async Task<EventosListaViewModel> GetAllAsync()
        {
            return await _eventoNegocio.GetAllAsync();
        }

        [Route("{key}")]
        public async Task<Evento> GetAsync([FromRoute] int key)
        {
            return  await _eventoNegocio.GetAsync(key);
        }

        [Route("Recomendacoes")]
        public async Task<ActionResult> GetEventosRecomendacoesAsync()
        {
            var eventos = await _eventoNegocio.GetEventosRecomendacoesAsync();
            if (eventos == null)
                return NotFound(new { message = "Eventos não encontrados" });

            return Ok(eventos);
        }

        [Route("EmAlta")]
        public async Task<ActionResult> GetEventosEmAltaAsync()
        {
            var eventos = await _eventoNegocio.GetEventosEmAltaAsync();
            if(eventos == null)
                return NotFound(new { message = "Eventos não encontrados"});

            return Ok(eventos);
        }

        [Route("UltimosVisitados")]
        public async Task<ActionResult> GetEventosUltimosVisitadosAsync()
        {
            var eventos = await _eventoNegocio.GetEventosUltimosVisitadosAsync();
            if (eventos == null)
                return NotFound(new { message = "Não Há Historico Recente" });

            return Ok(eventos);
        }

        [Route("Recomendado/{KeyEvento}")]
        public async Task<ActionResult> GetEventosSimilares([FromRoute]string KeyEvento)
        {
            if (string.IsNullOrEmpty(KeyEvento))
                return BadRequest(new { message = "Chave não informada" });
            var eventos = await _eventoNegocio.GetRecomendacoesPorEventoAsync(KeyEvento);
            if (eventos == null)
                return NotFound(new { message = "Sem Recomendações para esse evento" });
            return Ok(eventos);
        }

    }
}