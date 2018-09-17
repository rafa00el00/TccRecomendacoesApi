using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Dados
{




    public interface IEventoDados : IGenericDados<EventoDTO>
    {

        IList<string> GetAllTags();
    }

    public class EventoDados : GenericDados<EventoDTO> , IEventoDados
    {
        private readonly DbContext _context;

        public EventoDados(DbContext context):base(context)
        {
            this._context = context;
        }

        public IList<string> GetAllTags()
        {
            var tags = _context.Set<EventoDTO>()
                .Include(e => e.Tags)
                .SelectMany(e => e.Tags)
                .Select(t => t.TagName)
                .Distinct()
                .ToList();
            return tags;
        }

        public override async Task<EventoDTO> GetAsync(int key)
        {
            var evento = _context.Set<EventoDTO>().Include(e => e.Tags).FirstOrDefault(e => e.Id == key);
            return evento;
        }

    }

   

   
}
