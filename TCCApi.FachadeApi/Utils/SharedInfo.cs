using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;

namespace TCCApi.FachadeApi.Utils
{
    public static class SharedInfo
    {
        public static string CodUsuario;
        public static string Token;
        public static int CodEmpresa;
        public static Empresa empresa { get; set; }
        public static Usuario usuario { get; set; }

    }
}
