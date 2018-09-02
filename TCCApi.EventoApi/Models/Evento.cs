using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.EventoApi.Models
{
    public class Evento
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoSimples { get; set; }
        public string Descricao { get; set; }
        public IList<string> Tags { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }


        public int? IdEmpresa { get; set; }
        public string EmpresaNome { get; set; }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }


    }



}
