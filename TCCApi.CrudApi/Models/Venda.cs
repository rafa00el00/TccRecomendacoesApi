using System;

namespace TCCApi.CrudApi.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string CodigoTransacao { get; set; }
        public string CodigoRegerencia { get; set; }
        public DateTime DataVenda { get; set; }
        public string StatusVenda { get; set; }
        public DateTime DataCancelamento { get; set; }
        public Evento Evento { get; set; }
        public Cliente Cliente { get; set; }

    }


}
