using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.VendaApi.Models
{
    public class Compra
    {

        public int Id { get; set; }
        //Objeto Venda
        public string ItemID { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Qtd { get; set; }
        public DateTime DataEvento { get; set; }
        public DateTime DataCompra { get; set; }
        public string GuidCompra { get; set; }

        //Status
        public int CodStatus { get; set; }
        public string DescricaoStatus { get; set; }

        //Comprador
        public string GuidUsuario { get; set; }
        public string NomeComprador { get; set; }
        public string Cpf { get; set; }
        public string Ddd { get; set; }
        public string Celular { get; set; }
        public string EmailComprador { get; set; }

        //Vendedor
        public string GuidEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        //Pagamento
        public Pagamento Pagamento { get; set; }
        public string ModoPagamento { get; internal set; }
    }
    public class Pagamento
    {
        public int Id { get; set; }
        public string Cartao { get; set; }
        public string NomeTitular { get; set; }
        public string Vencimento { get; set; }
        public string Cvv { get; set; }

    }
}
