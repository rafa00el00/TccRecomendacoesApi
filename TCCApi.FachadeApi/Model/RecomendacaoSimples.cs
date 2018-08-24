using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.FachadeApi.Model
{
    public class RecomendacaoSimples
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public IList<string> Similares { get; set; }
    }
}
