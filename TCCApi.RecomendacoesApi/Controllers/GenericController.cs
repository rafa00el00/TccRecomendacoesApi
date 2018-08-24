using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TCCApi.RecomendacoesApi.Negocio;

namespace TCCApi.RecomendacoesApi.Controllers
{
    [Produces("application/json")]
    public abstract class GenericController<T,D> : Controller
    {
        protected readonly IGenericNegocio<T,D> _negocio;

        public GenericController(IGenericNegocio<T, D> negocio)
        {
            _negocio = negocio;
        }

        [Route("GetAll")]
        public IList<T> GetAll()
        {
            return _negocio.GetAll();
        }
    }
}