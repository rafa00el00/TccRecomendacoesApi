using System;

namespace TCCApi.Authenticacao.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string TelefoneContato { get; set; }
        public string Organizador { get; set; }
        public DateTime DataCriacao { get; set; }

    }



}
