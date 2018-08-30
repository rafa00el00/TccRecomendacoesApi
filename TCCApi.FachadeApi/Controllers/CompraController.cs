using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Negocio;

namespace TCCApi.FachadeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Compra")]
    public class CompraController : Controller
    {
        private readonly ICompraNegocio _compraNegocio;

        public CompraController(ICompraNegocio compraNegocio)
        {
            this._compraNegocio = compraNegocio;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int Id)
        {
            if (Id is default(int))
                return BadRequest(new { message = "Informe o id" });

            var compra = await _compraNegocio.GetAsync(Id);

            if (compra == null)
                return NotFound(new { message = "Compra não encontrada" });
            return Ok(compra);

        }

        [HttpGet]
        [Route("Usuario")]
        public async Task<IActionResult> GetPorUsuarioAsync()
        {
            
            var compra = await _compraNegocio.GetListaComprasAsync();

            if (compra == null)
                return NotFound(new { message = "Compra não encontrada" });
            return Ok(compra);

        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Compra compra)
        {
           
            var retorno = await _compraNegocio.PostCompraAsync(compra);

            if (retorno == null)
                return BadRequest(new { message = "Compra não efetuada" });
            return Ok(retorno);

        }
    }
}