using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Middleware
{
    public class GetUsuarioMiddleware : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            SharedInfo.CodUsuario = "usuario1";
        }
    }
}
