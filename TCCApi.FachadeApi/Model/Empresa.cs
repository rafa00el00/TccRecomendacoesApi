using System;

namespace TCCApi.FachadeApi.Models
{
    public class Empresa
    {
        public int Sub { get; set; }
        public string Name { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string TelefoneContato { get; set; }
        public string Organizador { get; set; }
        public DateTime DataCriacao { get; set; }


        public string Password { get; set; }
        public string Tipo { get; set; }

    }



}
