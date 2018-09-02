using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCApi.EventoApi.Models.DTO;
using TCCApi.EventoApi.Negocio;

namespace TCCApi.EventoApi.Controllers
{
    [Produces("application/json")]
    public abstract class GenericController<T,D> : Controller where D: DataBaseEntidade
    {
        protected IGenericNegocio<T, D> Negocio { get; set; }

        public GenericController(IGenericNegocio<T, D> negocio)
        {
            Negocio = negocio;
        }

        [Route("{key}")]
        public async Task<IActionResult> GetAsync([FromRoute] int key)
        {
            if (key == 0)
            {
                return BadRequest("Dado informado invalido");
            }

            return Ok(await Negocio.GetAsync(key));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Negocio.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync( [FromBody]T dado)
        {
            if (dado == null)
                return BadRequest("Dados não validos");

            var ret = await Negocio.AddAsync(dado);

            return Ok(ret);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]T dado)
        {
            if (dado == null)
                return BadRequest("Dados não validos");

            var ret = await Negocio.PutAsync(dado);

            return Ok(dado);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Dados não validos");

            var ret = await Negocio.RemoveAsync(id);

            return Ok("Deletado");
        }
    }
}