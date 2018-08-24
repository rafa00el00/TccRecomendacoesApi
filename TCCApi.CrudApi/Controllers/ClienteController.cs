using Microsoft.AspNetCore.Mvc;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;
using TCCApi.CrudApi.Negocio;

namespace TCCApi.CrudApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : GenericController<Cliente, ClienteDTO>
    {
        public ClienteController(IClienteNegocio clienteNegocio) : base(clienteNegocio)
        {

        }
    }
}