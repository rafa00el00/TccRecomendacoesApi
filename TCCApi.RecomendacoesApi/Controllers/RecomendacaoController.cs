using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCCApi.RecomendacoesApi.Models;
using TCCApi.RecomendacoesApi.Models.DTO;
using TCCApi.RecomendacoesApi.Negocio;

namespace TCCApi.RecomendacoesApi.Controllers
{

    [Route("api/Recomendacao")]
    public class RecomendacaoController : GenericController<RecomendacaoSimples, RecomendacoesSimplesTO>
    {
        private readonly IRecomendacoesSimplesNegocio negocio;

        public RecomendacaoController(IRecomendacoesSimplesNegocio negocio) : base(negocio)
        {
            this.negocio = negocio;
        }


        [Route("{key}")]
        public RecomendacaoSimples Get([FromRoute] string key)
        {
            return this.negocio.Get(key);
        }
    }
}