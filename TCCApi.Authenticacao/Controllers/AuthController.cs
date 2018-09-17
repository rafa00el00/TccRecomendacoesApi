using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.Authenticacao.Dados;
using TCCApi.Authenticacao.Models;

namespace TCCApi.Authenticacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IApplicationUserDados _applicationUserDados;

        public AuthController(IApplicationUserDados applicationUserDados)
        {
            this._applicationUserDados = applicationUserDados;
        }

        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> PostUsuarioAsync([FromBody]ApplicationUserTO applicationUser)
        {
            var usuario = new ApplicationUser()
            {
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                Claims = applicationUser.Claims
            };
            usuario.Claims.Add(new MyClaim("guidusuario", Guid.NewGuid().ToString()));
            usuario.Claims.Add(new MyClaim("tipo", "usuario"));
            try
            {
                usuario = await _applicationUserDados.AddAsync(usuario, applicationUser.Password);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"não foi possivel cadastrar Erro[{ex.Message}]");
            }
            return Ok(usuario);
        }
        [HttpPost]
        [Route("Empresa")]
        public async Task<IActionResult> PostEmpresaAsync([FromBody]ApplicationUserTO applicationUser)
        {
            var usuario = new ApplicationUser()
            {
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                Claims = applicationUser.Claims
            };
            usuario.Claims.Add(new MyClaim("tipo", "empresa"));
            try
            {
                usuario = await _applicationUserDados.AddAsync(usuario, applicationUser.Password);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"não foi possivel cadastrar Erro[{ex.Message}]");
            }
            return Ok(usuario);
        }

        public class ApplicationUserTO
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public IList<MyClaim> Claims { get; set; }
        }
    }
}