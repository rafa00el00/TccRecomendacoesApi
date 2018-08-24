using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TCCApi.RecomendacoesApi.Dados.DadosRecomendacoes;
using TCCApi.RecomendacoesApi.Models;
using TCCApi.RecomendacoesApi.Models.DTO;

namespace TCCApi.RecomendacoesApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRecomendacoesEventosDados _recomendacoesEventosDados;

        public ValuesController(IRecomendacoesEventosDados recomendacoesEventosDados)
        {
          _recomendacoesEventosDados = recomendacoesEventosDados;
        }

        // GET api/values
        [HttpGet]
        public IList<RecomendacaoSimples> Get()
        {
            return Mapper.Map< IList<RecomendacaoSimples>>( _recomendacoesEventosDados.GetAll().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
