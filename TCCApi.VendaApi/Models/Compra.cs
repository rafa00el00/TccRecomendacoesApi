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
        public DateTime DataCompra { get; set; }
        public string Status { get; set; }
        public string ModoPagamento { get; set; }

        //Comprador
        public string GuidUsuario { get; set; }
        public string NomeComprador { get; set; }
        public string Cpf { get; set; }
        public string Ddd { get; set; }
        public string Celular { get; set; }
        public string EmailComprador { get; set; }
        public string HashComprador { get; set; }

        //Vendedor
        public string GuidEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        

    }
}
