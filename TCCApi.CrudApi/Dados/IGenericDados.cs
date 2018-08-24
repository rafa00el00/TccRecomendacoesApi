using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{
  
    public interface IGenericDados<T> 
        where T : DataBaseEntidade
    {
        Task<T> GetAsync(int key);
        IQueryable<T> GetAll();
        Task<int> AddAsync(T entidade);
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

        public Task<T> GetAsync(int key)
        {
            return _context.FindAsync<T>(key);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public Task<int> AddAsync(T entidade)
        {
            _context.AddAsync<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Added;

            return _context.SaveChangesAsync();
        }

        public Task<int> PutAsync(T entidade)
        {
            _context.Update<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public Task<int> RemoveAsync(T entidade)
        {
            //_context.Remove<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Deleted;

            return _context.SaveChangesAsync();
        }

        public Task<EntityEntry<T>> AddTempAsync(T entidade)
        {
            var ret = _context.AddAsync<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public EntityEntry<T> PutTemp(T entidade)
        {
            var ret = _context.Update<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public EntityEntry<T> RemoveTemp(T entidade)
        {
            var ret = _context.Remove<T>(entidade);
            _context.Entry<T>(entidade).State = EntityState.Detached;
            return ret;
        }

        public Task<int> SaveAllChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
