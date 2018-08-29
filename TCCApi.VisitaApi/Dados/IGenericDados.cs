using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.VisitaApi.Models;

namespace TCCApi.VisitaApi.Dados
{
    public interface IVisitaDados
    {
        Task<int> AddAsync(Visita entidade);
        IQueryable<Visita> GetAll();
        Task<Visita> GetAsync(int key);
        Task<int> PutAsync(Visita entidade);
        Task<int> RemoveAsync(Visita entidade);
    }

    public class VisitaDados : IVisitaDados
    {
        private readonly DbContext _context;

        public VisitaDados(DbContext context)
        {
            this._context = context;
        }
        public virtual Task<Visita> GetAsync(int key)
        {
            return _context.FindAsync<Visita>(key);
        }

        public virtual IQueryable<Visita> GetAll()
        {
            return _context.Set<Visita>().AsQueryable();
        }

        public virtual Task<int> AddAsync(Visita entidade)
        {
            _context.AddAsync<Visita>(entidade);
            _context.Entry<Visita>(entidade).State = EntityState.Added;

            return _context.SaveChangesAsync();
        }

        public virtual Task<int> PutAsync(Visita entidade)
        {
            _context.Update<Visita>(entidade);
            _context.Entry<Visita>(entidade).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public virtual Task<int> RemoveAsync(Visita entidade)
        {
            //_context.Remove<T>(entidade);
            _context.Entry<Visita>(entidade).State = EntityState.Deleted;

            return _context.SaveChangesAsync();
        }
    }
}