using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Middleware
{
    public class GetUsuarioMiddleware : IActionFilter
    {
        private readonly IAuthService _authService;

        public GetUsuarioMiddleware(IAuthService authService)
        {
            this._authService = authService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            var token = new StringValues();
            var tipo = new StringValues();
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            context.HttpContext.Request.Headers.TryGetValue("Tipo", out tipo);
            SharedInfo.Token = token.FirstOrDefault();
            var tp = tipo.FirstOrDefault();

            if(tp != null && SharedInfo.Token != null)
            {
                if (tp.ToUpper().Equals("USUARIO"))
                {
                    var usuario = await _authService.GetUsuarioLogadoAsync();
                    SharedInfo.CodUsuario = usuario.GuidUsuario;
                    SharedInfo.usuario = usuario;
                }
                else if (tp.ToUpper().Equals("EMPRESA"))
                {
                    var empresa = await _authService.GetEmpresaLogadoAsync();
                    SharedInfo.CodEmpresa = empresa.Sub;
                    SharedInfo.empresa = empresa;
                }
            }

            
            
        }
    }
}
