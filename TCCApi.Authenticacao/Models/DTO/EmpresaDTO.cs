using System;

namespace TCCApi.Authenticacao.Models.DTO
{
    public class EmpresaDTO : DataBaseEntidade
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string TelefoneContato { get; set; }
        public string Organizador { get; set; }
        public DateTime DataCriacao { get; set; }

    }


}
