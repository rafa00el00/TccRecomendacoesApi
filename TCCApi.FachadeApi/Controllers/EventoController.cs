using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<EventoDetalhesViewModel> GetAsync([FromRoute] int key)
        {
            
            return  await _eventoNegocio.GetAsync(key);
        }

    }
}