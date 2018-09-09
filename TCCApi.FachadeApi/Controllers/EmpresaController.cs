using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Models;
using TCCApi.FachadeApi.Negocio;

namespace TCCApi.FachadeApi.Controllers
{


    [Produces("application/json")]
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaNegocio _empresaNegocio;

        public EmpresaController(IEmpresaNegocio empresaNegocio)
        {
            this._empresaNegocio = empresaNegocio;
        }

        [Route("{key}")]
        public async Task<Empresa> GetAsync([FromRoute] int key)
        {
            return await _empresaNegocio.GetAsync(key);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Empresa empresa)
        {
            if (empresa is default(Empresa))
                return BadRequest(new { message = "Não é possivel cadastrar uma nova empresa sem os dados" });

            await _empresaNegocio.PostAsync(empresa);
            return Ok(new { message = "Empresa Cadastrada com sucesso" });
        }
    }
}