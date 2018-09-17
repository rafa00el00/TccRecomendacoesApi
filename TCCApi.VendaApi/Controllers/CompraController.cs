using Microsoft.AspNetCore.Mvc;
using TCCApi.VendaApi.Models;
using TCCApi.VendaApi.Models.DTO;
using TCCApi.VendaApi.Negocio;

namespace TCCApi.VendaApi.Controllers
{
    [Route("api/[controller]")]
    public class CompraController : GenericController<Compra, CompraDTO>
    {
        private readonly ICompraNegocio _negocio;

        public CompraController(ICompraNegocio negocio) : base(negocio)
        {
            this._negocio = negocio;
        }

        [HttpGet]
        [Route("Usuario/{guidUsuario}")]
        public IActionResult GetComprasUsuario([FromRoute]string guidUsuario)
        {
            if (string.IsNullOrWhiteSpace(guidUsuario))
            {
                return BadRequest("Informe o usuario");
            }

            return Ok(_negocio.GetComprasUsuario(guidUsuario));
        }
        [HttpGet]
        [Route("Empresa/{codEmpresa}")]
        public IActionResult GetComprasEmpresa([FromRoute]string codEmpresa)
        {
            if (string.IsNullOrWhiteSpace(codEmpresa))
            {
                return BadRequest("Informe o usuario");
            }

            return Ok(_negocio.GetComprasEmpresa(codEmpresa));
        }
    }
}
