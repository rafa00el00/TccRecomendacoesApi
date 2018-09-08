using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.VendaApi.Models.DTO;

namespace TCCApi.VendaApi.Dados
{




    public interface ICompraDados : IGenericDados<CompraDTO>
    {
        
    }

    public class CompraDados : GenericDados<CompraDTO> , ICompraDados
    {
        private readonly DbContext _context;

        public CompraDados(DbContext context):base(context)
        {
            this._context = context;
        }

        

    }

   

   
}
