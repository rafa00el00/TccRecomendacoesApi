using System;

namespace TCCApi.FachadeApi.Model.TO
{
    public class ItemCompra
    {
        public string Titulo { get; set; }
        public string DescricaoSimples { get; set; }
        public string Img { get; set; }
        public DateTime DataEvento { get; set; }
        public int Status { get; set; }
        public string DescricaoStatus { get; set; }
        public string CodEvento { get; set; }
    }
}
