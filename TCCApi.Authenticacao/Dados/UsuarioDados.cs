using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Dados
{




    public interface IUsuarioDados : IGenericDados<UsuarioDTO>
    {
        
    }
    public class UsuarioDados : GenericDados<UsuarioDTO> , IUsuarioDados
    {
        private readonly DbContext _context;

        public UsuarioDados(DbContext context):base(context)
        {
            this._context = context;
        }

        public override async Task<UsuarioDTO> GetAsync(int key)
        {
            var evento = _context.Set<UsuarioDTO>().Include(e => e.Tags).FirstOrDefault(e => e.Id == key);
            return evento;
        }

    }

   

   
}
