using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.VendaApi.Dados;
using TCCApi.VendaApi.Models;
using TCCApi.VendaApi.Models.DTO;

namespace TCCApi.VendaApi.Negocio
{


    public interface ICompraNegocio: IGenericNegocio<Compra,CompraDTO>
    {
        IList<Compra> GetComprasUsuario(string guidUsuario);
        IList<Compra> GetComprasEmpresa(string codEmpresa);
    }

    public class CompraNegocio : GenericNegocio<Compra,CompraDTO> , ICompraNegocio
    {
        private readonly ICompraDados _compraDados;

        public CompraNegocio(ICompraDados CompraDados) : base(CompraDados)
        {
            _compraDados = CompraDados;
        }

        public override Task<Compra> AddAsync(Compra entidade)
        {
            entidade.DataCompra = DateTime.Now;
            entidade.ModoPagamento = "efd";
            return base.AddAsync(entidade);
        }

        public IList<Compra> GetComprasUsuario(string guidUsuario)
        {
            var compraDt = _compraDados.GetAll().Where(c => c.GuidUsuario.Equals(guidUsuario)).ToList();

            return Mapper.Map<IList<Compra>>(compraDt);
        }

        public IList<Compra> GetComprasEmpresa(string codEmpresa)
        {
            var compraDt = _compraDados.GetAll().Where(c => c.GuidEmpresa.Equals(codEmpresa)).ToList();

            return Mapper.Map<IList<Compra>>(compraDt);
        }

    }

    

    





}
