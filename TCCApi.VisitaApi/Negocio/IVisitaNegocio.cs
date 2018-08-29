using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.VisitaApi.Models;

namespace TCCApi.VisitaApi.Negocio
{
    public interface IVisitaNegocio
    {
        Task AddAsync(Visita visita);
        Task<Visita> GetAsync(int id);
        IList<int> GetTopMost();
        IList<Visita> GetUltimasVisitas(string guidUsuario);
    }
}