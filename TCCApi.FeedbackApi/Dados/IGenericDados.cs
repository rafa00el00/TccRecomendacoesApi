using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FeedbackApi.Models.DTO;

namespace TCCApi.FeedbackApi.Dados
{

    public interface IGenericDados<T> 
        where T : DataBaseEntidade
    {
        Task<T> GetAsync(int key);
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entidade);
        Task<int> PutAsync(T entidade);
        Task<int> RemoveAsync(T entidade);

        Task<EntityEntry<T>> AddTempAsync(T entidade);
        EntityEntry<T> PutTemp(T entidade);
        EntityEntry<T> RemoveTemp(T entidade);
        Task<int> SaveAllChanges();
    }

    public class GenericDados<T> : IGenericDados<T> where T : DataBaseEntidade
    {
        protected readonly DbContext _context;

        public GenericDados(DbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual Task<T> GetAsync(int key)
        {
            return _context.FindAsync<T>(key);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual async Task<T> AddAsync(T entidade)
        {
           await  _context.AddAsync<T>(entidade);
            //_context.Entry<T>(entidade).State = EntityState.Added;

           await  _context.SaveChangesAsync();
            return entidade;
        }

        public virtual Task<int> PutAsync(T entidade)
        {
            _context.Update<T>(entidade);
            //_context.Entry<T>(entidade).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public virtual Task<int> RemoveAsync(T entidade)
        {
            //_context.Remove<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Deleted;

            return _context.SaveChangesAsync();
        }

        public virtual Task<EntityEntry<T>> AddTempAsync(T entidade)
        {
            var ret = _context.AddAsync<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public virtual EntityEntry<T> PutTemp(T entidade)
        {
            var ret = _context.Update<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public virtual EntityEntry<T> RemoveTemp(T entidade)
        {
            var ret = _context.Remove<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public virtual Task<int> SaveAllChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
