using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Services
{
    public interface ICompraService
    {
        string BaseUrl { get; }

        Task<Compra> GetAsync(int key);
        Task<IList<Compra>> GetListaCompras(string guidUsuario);
        Task<Compra> PostCompra(Compra compra);
    }
}