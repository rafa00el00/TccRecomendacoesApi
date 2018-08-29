using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.VisitaApi.Models
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string GuidUsuario { get; set; }
        public DateTime DataVisita { get; set; }
    }
}
