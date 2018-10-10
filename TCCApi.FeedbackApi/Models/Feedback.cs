using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.FeedbackApi.Models
{
    public class Feedback
    {

        public int Id { get; set; }
        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Mensagem { get; set; }
        public int Rate { get; set; }
        public string CodEvento { get; set; }


    }



}
