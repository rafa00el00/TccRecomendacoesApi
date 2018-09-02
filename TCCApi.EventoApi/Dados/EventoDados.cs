using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Dados
{




    public interface IEventoDados : IGenericDados<EventoDTO>
    {
        
    }

    public class EventoDados : GenericDados<EventoDTO> , IEventoDados
    {
        private readonly DbContext _context;

        public EventoDados(DbContext context):base(context)
        {
            this._context = context;
        }

        public override async Task<EventoDTO> GetAsync(int key)
        {
            var evento = _context.Set<EventoDTO>().Include(e => e.Tags).FirstOrDefault(e => e.Id == key);
            return evento;
        }

    }

   

   
}
