using System;

namespace TCCApi.FachadeApi.Model.TO
{
    public class VisitaTO
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string GuidUsuario { get; set; }
        public DateTime DataVisita { get; set; }
    }
}
