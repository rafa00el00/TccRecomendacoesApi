using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.FachadeApi.Model
{
    public class Evento
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoSimples { get; set; }
        public double Valor { get; set; }
        public IList<string> Tags { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public string PublicoAlvo { get; set; }

    }
}
