﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.EventoApi.Dados;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Negocio
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

        public async Task<T> AddAsync(T entidade)
        {
            var ret = await _dados.AddAsync(Mapper.Map<D>(entidade));
            return Mapper.Map<T>(ret);

        }

        public IList<T> GetAll()
        {
            return Mapper.Map<IList<T>>(_dados.GetAll().ToList());
        }

        public IList<T> GetAll(int page, int num)
        {
            return Mapper.Map<IList<T>>(_dados.GetAll().Skip(num * page).Take(num).ToList());
        }

        public async Task<T> GetAsync(int key)
        {
            return Mapper.Map<T>(await _dados.GetAsync(key));
        }

        public Task<int> PutAsync(T entidade)
        {
            return _dados.PutAsync(Mapper.Map<D>(entidade));
        }

        public async Task<int> RemoveAsync(int id)
        {
            var dado = await GetAsync(id);
            return await _dados.RemoveAsync(Mapper.Map<D>(dado));
        }
    }
}
