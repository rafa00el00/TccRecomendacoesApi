using System;
using System.Threading.Tasks;
using TCCApi.VendaApi.Dados;
using TCCApi.VendaApi.Models;
using TCCApi.VendaApi.Models.DTO;

namespace TCCApi.VendaApi.Negocio
{


    public interface ICompraNegocio: IGenericNegocio<Compra,CompraDTO>
    {
        
    }

    public class CompraNegocio : GenericNegocio<Compra,CompraDTO> , ICompraNegocio
    {
        

        public CompraNegocio(ICompraDados CompraDados) : base(CompraDados)
        {
            
        }

        public override Task<Compra> AddAsync(Compra entidade)
        {
            entidade.DataCompra = DateTime.Now;
            entidade.ModoPagamento = "efd";
            return base.AddAsync(entidade);
        }


    }

    

    





}
