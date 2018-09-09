using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Models.DTO;
using TCCApi.Authenticacao.Negocio;

namespace TCCApi.Authenticacao.Controllers
{

    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsarioController : GenericController<Usuario, UsuarioDTO>
    {
        public UsarioController(IUsuarioNegocio usuarioNegocio) : base(usuarioNegocio)
        {

        }
        [Route("profile")]
        public IActionResult Get()
        {
            var caller = User as ClaimsPrincipal;
            return Ok(caller.Claims.ToList());
        }
    }
}