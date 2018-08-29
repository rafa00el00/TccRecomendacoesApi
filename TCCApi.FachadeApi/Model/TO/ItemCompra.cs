using System;

namespace TCCApi.FachadeApi.Model.TO
{
    public class ItemCompra
    {
        public string Titulo { get; set; }
        public string DescricaoSimples { get; set; }
        public string Img { get; set; }
        public DateTime DataEvento { get; set; }
        public string Status { get; set; }
    }
}
