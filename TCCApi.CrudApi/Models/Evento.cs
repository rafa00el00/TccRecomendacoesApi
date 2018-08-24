using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.CrudApi.Models
{
    public class Evento
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IList<string> Tags { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public string PublicoAlvo { get; set; }
        public IList<Localizacao> Locais { get; set; }
        public IList<FotoEvento> Fotos { get; set; }

        public Empresa  Empresa { get; set; }

    }

    public class FotoEvento
    {
        public int Id { get; set; }
        public string CaminhoFoto { get; set; }
        public Evento Evento { get; set; }
    }

}
