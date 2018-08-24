using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;
using TCCApi.CrudApi.Negocio;

namespace TCCApi.CrudApi.Controllers
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