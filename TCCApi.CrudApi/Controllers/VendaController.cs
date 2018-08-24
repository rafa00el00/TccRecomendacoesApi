using Microsoft.AspNetCore.Mvc;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;
using TCCApi.CrudApi.Negocio;

namespace TCCApi.CrudApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Venda")]
    public class VendaController : GenericController<Venda, VendaDTO>
    {
        public VendaController(IVendaNegocio vendaNegocio) : base(vendaNegocio)
        {

        }
    }
}