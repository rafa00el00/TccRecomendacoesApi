using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.VisitaApi.Dados;
using TCCApi.VisitaApi.Models;

namespace TCCApi.VisitaApi.Negocio
{
    public class VisitaNegocio : IVisitaNegocio
    {
        private readonly IVisitaDados _visitaDados;

        public VisitaNegocio(IVisitaDados visitaDados)
        {
            this._visitaDados = visitaDados;
        }

        public async Task<Visita> GetAsync(int id)
        {
            return await _visitaDados.GetAsync(id);
        }
        
        public async Task AddAsync(Visita visita)
        {
            visita.DataVisita = DateTime.Now;
            await _visitaDados.AddAsync(visita);
        }

        public IList<Visita> GetUltimasVisitas(string guidUsuario)
        {
            var visitas =  _visitaDados.GetAll()
                .Where(v => v.GuidUsuario.Equals(guidUsuario))
                .OrderByDescending(c => c.DataVisita)
                .Take(30)
                .ToList();

            return visitas;
        }

        public IList<int> GetTopMost()
        {
            var mes = DateTime.Now.AddDays(-30);
            var visitas = _visitaDados.GetAll()
                .Where(v => v.DataVisita >= mes)
                .GroupBy(c => c.IdEvento, s => s.IdEvento)
                .Select(e => e.Key)
                .Take(30)
                .ToList();

            return visitas;
        }

    }
}
