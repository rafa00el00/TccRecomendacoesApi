using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.Authenticacao.Models.DTO
{
    public abstract class DataBaseEntidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class UsuarioDTO : DataBaseEntidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cpf { get; set; }
        public IList<ClienteTagDTO> Tags { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }


        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        

    }

    public class ClienteTagDTO : DataBaseEntidade
    {
        public string TagName { get; set; }
    }


}
