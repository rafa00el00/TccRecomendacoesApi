using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.CrudApi.Models.DTO
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
        public IList<LocalizacaoDTO> Locais { get; set; }
        public IList<FotoEventoDto> Fotos { get; set; }

        [ForeignKey("Empresa")]
        public int? IdEmpresa { get; set; }

        public virtual EmpresaDTO Empresa { get; set; }

    }

    public class EventoTagDTO : DataBaseEntidade
    {
        public string TagName { get; set; }
    }

    public class LocalizacaoDTO : DataBaseEntidade
    {
        
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }

    public class ClienteDTO :DataBaseEntidade
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
      
        [MaxLength(11)]
        public string CPF { get; set; }
        public IList<Localizacao> Locais { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }

        [InverseProperty("Cliente")]
        public IList<VendaDTO> Compras { get; set; }

    }


    public class VendaDTO: DataBaseEntidade
    {
        public string CodigoTransacao { get; set; }
        public string CodigoRegerencia { get; set; }
        public DateTime DataVenda { get; set; }
        public string StatusVenda { get; set; }
        public DateTime DataCancelamento { get; set; }

        [ForeignKey("Evento")]
        public int? IdEvento { get; set; }
        [ForeignKey("Cliente")]
        public int? IdCLiente { get; set; }

        public virtual EventoDTO Evento { get; set; }
        public virtual ClienteDTO Cliente { get; set; }

    }

    public class EmpresaDTO : DataBaseEntidade
    {
        [MaxLength(40)]
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [InverseProperty("Empresa")]
        public IList<EventoDTO> Eventos { get; set; }
    }

    public class FotoEventoDto : DataBaseEntidade
    {
        public string CaminhoFoto { get; set; }

        [ForeignKey("Evento")]
        public int IdEvento { get; set; }

        public virtual EventoDTO Evento { get; set; }
    }

}
