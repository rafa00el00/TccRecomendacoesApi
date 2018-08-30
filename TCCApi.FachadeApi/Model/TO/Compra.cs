namespace TCCApi.FachadeApi.Model.TO
{
    public class Compra
    {
        public int Id { get; set; }
        public string GuidCompra { get; set; }
        public int CodEvento { get; set; }
        public string NomeEvento { get; set; }
        public int QtdIngressos { get; set; }
        public double ValorTotal { get; set; }
        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CodEmpresa { get; set; }

        //Meio de Pagamento
        //Status

    }
}
