using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TCCApi.RecomendacoesTexto.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<string> Post([FromBody]PostValue value)
        {

            //Rake.Rake rake = new Rake.Rake("stopwords.txt");
            Rake.Rake rake = new Rake.Rake();

            var teste = rake.Run(value.Value);

            return teste.Where((s,d) => s.Value > 1).Select((s,d) => s.Key);

        }

        public class PostValue
        {
            public string Value { get; set; }
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
