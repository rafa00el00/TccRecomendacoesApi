using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCApi.VisitaApi.Models;
using TCCApi.VisitaApi.Negocio;

namespace TCCApi.VisitaApi.Controllers
{

    [Route("api/Visita")]
    public class VisitaController : Controller
    {
        private readonly IVisitaNegocio _visitaNegocio;

        public VisitaController(IVisitaNegocio visitaNegocio)
        {
            this._visitaNegocio = visitaNegocio;
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitaAsync([FromBody]Visita visita)
        {
            if(visita == null || visita == default(Visita))
                   return BadRequest(new { message = "Valores invalidos"});

            await _visitaNegocio.AddAsync( visita);

            return Ok("Adicionado");
        }

        [HttpGet]
        [Route("UltimasVisitas/{guidUsuario}")]
        public IActionResult GetVisitasUsuario([FromRoute] string guidUsuario)
        {

            if (string.IsNullOrWhiteSpace(guidUsuario))
                return BadRequest(new { message = "Guid usuario não informado" });

            var visitas = _visitaNegocio.GetUltimasVisitas(guidUsuario);
            return Ok(visitas);
        }

        [HttpGet]
        [Route("TopMost")]
        public IActionResult GetTopMost()
        {
            var eventos = _visitaNegocio.GetTopMost();
            return Ok(eventos);
        }

    }
}
