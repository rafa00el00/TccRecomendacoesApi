﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.RecomendacoesApi.Models
{
    public class RecomendacaoSimples
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public IList<string> Similares { get; set; }
    }
}
