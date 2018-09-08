using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.VendaApi.Dados;
using TCCApi.VendaApi.Models.DTO;

namespace TCCApi.VendaApi.Negocio
{
    public interface IGenericNegocio<T,D>
    {
        Task<T> GetAsync(int key);
        IList<T> GetAll();
        Task<T> AddAsync(T entidade);
        Task<int> PutAsync(T entidade);
        Task<int> RemoveAsync(int Id);
        IList<T> GetAll(int page, int qtd);
    }

    public abstract class GenericNegocio<T, D> : IGenericNegocio<T, D> where D : DataBaseEntidade
    {

        protected IGenericDados<D> _dados { get; set; }

        public GenericNegocio(IGenericDados<D> dados)
        {
            _dados = dados;
        }

        public virtual async Task<T> AddAsync(T entidade)
        {
            var ret = await _dados.AddAsync(Mapper.Map<D>(entidade));
            return Mapper.Map<T>(ret);

        }

        public virtual IList<T> GetAll()
        {
            return Mapper.Map<IList<T>>(_dados.GetAll().ToList());
        }

        public virtual IList<T> GetAll(int page, int num)
        {
            return Mapper.Map<IList<T>>(_dados.GetAll().Skip(num * page).Take(num).ToList());
        }

        public virtual async Task<T> GetAsync(int key)
        {
            return Mapper.Map<T>(await _dados.GetAsync(key));
        }

        public virtual Task<int> PutAsync(T entidade)
        {
            return _dados.PutAsync(Mapper.Map<D>(entidade));
        }

        public virtual async Task<int> RemoveAsync(int id)
        {
            var dado = await GetAsync(id);
            return await _dados.RemoveAsync(Mapper.Map<D>(dado));
        }
    }
}
