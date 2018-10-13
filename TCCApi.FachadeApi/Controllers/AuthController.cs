using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;
using TCCApi.FachadeApi.Negocio;

namespace TCCApi.FachadeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public  class AuthController:Controller
    {
        private readonly IAuthNegocio _authNegocio;

        public AuthController(IAuthNegocio authNegocio)
        {
            this._authNegocio = authNegocio;
        }

        public class LoginTO
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        [HttpPost]
        [Route("DoLogin/{tipo}")]
        public async Task<IActionResult> DoLoginAsync([FromBody]LoginTO login,[FromRoute]string tipo)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return BadRequest(new { message = "Informe o usuario e senha" });

            try
            {
                TokenResult token;
                if (tipo.ToUpper().Equals("USUARIO"))
                {
                    token = await _authNegocio.DoLoginUsuarioAsync(login.email, login.password);

                }else if (tipo.ToUpper().Equals("EMPRESA"))
                {
                    token = await _authNegocio.DoLoginEmpresaAsync(login.email, login.password);
                }else
                {
                    return NotFound("Tipo não encontrado");
                }
                    return Ok(token);
            }
            catch (System.Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

            
        }

        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> CadastroUsuarioAsync([FromBody]Usuario usuario)
        {
            if (usuario == default(Usuario))
                return BadRequest(new { message = "Informe o Usuario" });

            try
            {
                var r = await _authNegocio.RegisterUsuario(usuario);
                return Ok(r);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

            
        }

        [HttpPost]
        [Route("Empresa")]
        public async Task<IActionResult> CadastroEmpresaAsync([FromBody]Empresa empresa)
        {
            if (empresa == null || empresa == default(Empresa))
                return BadRequest(new { message = "Informe o Usuario" });

            var r = await _authNegocio.RegisterEmpresa(empresa);

            return Ok(r);
        }

        [HttpGet]
        [Route("Usuario")]
        public async Task<IActionResult> GetUsuarioLogadoAsync()
        {
            var usuario = await _authNegocio.GetUsuarioAsync();

            if (usuario == null)
                return NotFound(new { message = "Usuario não encontrado" });

            return Ok(usuario);
        }

        [HttpGet]
        [Route("Empresa")]
        public async Task<IActionResult> GetEmpresaLogadoAsync()
        {
            var usuario = await _authNegocio.GetEmpresaAsync();

            if (usuario == null)
                return NotFound(new { message = "Usuario não encontrado" });

            return Ok(usuario);
        }
    }
}