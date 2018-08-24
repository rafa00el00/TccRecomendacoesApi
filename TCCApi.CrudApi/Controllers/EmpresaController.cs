using Microsoft.AspNetCore.Mvc;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;
using TCCApi.CrudApi.Negocio;

namespace TCCApi.CrudApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Empresa")]
    public class EmpresaController : GenericController<Empresa, EmpresaDTO>
    {
        public EmpresaController(IEmpresaNegocio empresaNegocio) : base(empresaNegocio)
        {

        }
    }
}