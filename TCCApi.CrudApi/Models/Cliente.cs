using System.Collections.Generic;

namespace TCCApi.CrudApi.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public IList<Localizacao> Locais { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

    }

}
