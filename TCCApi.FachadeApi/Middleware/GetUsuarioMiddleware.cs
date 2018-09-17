using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Middleware
{

    public class GetUsuarioMiddleware : IAsyncActionFilter
    {
        private readonly IAuthService _authService;
        private readonly SharedInfo sharedInfo;

        public GetUsuarioMiddleware(IAuthService authService, SharedInfo sharedInfo)
        {
            this._authService = authService;
            this.sharedInfo = sharedInfo;
        }

       

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = new StringValues();
            var tipo = new StringValues();
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            context.HttpContext.Request.Headers.TryGetValue("Tipo", out tipo);
            sharedInfo.Token = token.FirstOrDefault();
            var tp = tipo.FirstOrDefault();

            if (tp != null && sharedInfo.Token != null && !sharedInfo.Token.Contains("undefined"))
            {
                if (tp.ToUpper().Equals("USUARIO"))
                {
                    var usuario = await _authService.GetUsuarioLogadoAsync();
                    sharedInfo.CodUsuario = usuario.GuidUsuario;
                    sharedInfo.usuario = usuario;
                }
                else if (tp.ToUpper().Equals("EMPRESA"))
                {
                    var empresa = await _authService.GetEmpresaLogadoAsync();
                    sharedInfo.CodEmpresa = empresa.Sub;
                    sharedInfo.empresa = empresa;
                }
            }

            var resultContext = await next();
        }
    }
}
