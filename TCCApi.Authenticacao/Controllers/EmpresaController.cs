using Microsoft.AspNetCore.Mvc;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Models.DTO;
using TCCApi.Authenticacao.Negocio;

namespace TCCApi.Authenticacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Empresa")]
    public class EmpresaController : GenericController<Empresa, EmpresaDTO>
    {
        public EmpresaController(IEmpresaNegocio negocio) : base(negocio)
        {
        }
    }
}