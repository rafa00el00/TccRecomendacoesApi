using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.FeedbackApi.Models.DTO
{
    public abstract class DataBaseEntidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class FeedbackDTO : DataBaseEntidade
    {

        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Mensagem { get; set; }
        public int Rate { get; set; }
        public string CodEvento { get; set; }


    }

  

}
