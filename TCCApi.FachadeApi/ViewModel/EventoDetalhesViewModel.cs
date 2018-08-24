using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.ViewModel
{
    public class EventoDetalhesViewModel
    {
        public Evento Evento { get; set; }
        public IList<Evento> Similares { get; set; }
    }
}
