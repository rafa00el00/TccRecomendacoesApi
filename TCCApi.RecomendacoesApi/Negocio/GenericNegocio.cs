using AutoMapper;
using System.Collections.Generic;
using TCCApi.RecomendacoesApi.Dados.Configuracoes;

namespace TCCApi.RecomendacoesApi.Negocio
{

    /// <summary>
    /// Interface de negocio basica para trazer do banco e converter
    /// </summary>
    /// <typeparam name="T">Type do Objeto Modelo</typeparam>
    /// <typeparam name="D">Type do objeto de DTO (Banco de Dados)</typeparam>
    public interface IGenericNegocio<T, D>
    {
        IList<T> GetAll();
    }

    /// <summary>
    /// Implementação das funçoes genericas para trazer do banco e converter
    /// </summary>
    /// <typeparam name="T">Type do Objeto Modelo</typeparam>
    /// <typeparam name="D">Type do objeto de DTO (Banco de Dados)</typeparam>
    public abstract class GenericNegocio<T,D> : IGenericNegocio<T,D>
    {
        protected readonly IGenericMongoDados<D> _db;

        public GenericNegocio(IGenericMongoDados<D> db)
        {
            _db = db;
        }

        public IList<T> GetAll()
        {
            return Mapper.Map<IList<T>>(_db.GetAll());
        }
    }
}
