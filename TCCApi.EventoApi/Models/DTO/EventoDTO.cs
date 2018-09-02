using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.EventoApi.Models.DTO
{
    public abstract class DataBaseEntidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class EventoDTO : DataBaseEntidade
    {
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoSimples { get; set; }
        public double Valor { get; set; }
        public IList<EventoTagDTO> Tags { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public string PublicoAlvo { get; set; }
        
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

    public class EventoTagDTO : DataBaseEntidade
    {
        public string TagName { get; set; }
    }


}
