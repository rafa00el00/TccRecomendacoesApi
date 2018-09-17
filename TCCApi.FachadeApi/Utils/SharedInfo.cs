using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;

namespace TCCApi.FachadeApi.Utils
{
    public class SharedInfo
    {
        public string CodUsuario;
        public string Token;
        public int CodEmpresa;
        public Empresa empresa { get; set; }
        public Usuario usuario { get; set; }

    }
}
