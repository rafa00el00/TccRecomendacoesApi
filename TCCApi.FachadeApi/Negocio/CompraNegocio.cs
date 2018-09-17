using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Services.Recomendacao;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Negocio
{


    public interface ICompraNegocio
    {

        Task<Compra> GetAsync(int key);
        Task<IList<ItemCompra>> GetListaComprasAsync();
        Task<Compra> PostCompraAsync(Compra compra);
    }
    public class CompraNegocio : ICompraNegocio
    {
        private readonly ICompraService _compraService;
        private readonly IUsuarioRecomendacaoService _usuarioRecomendacaoService;
        private readonly SharedInfo sharedInfo;

        public CompraNegocio(ICompraService compraService,
            IUsuarioRecomendacaoService usuarioRecomendacaoService,
            SharedInfo sharedInfo
            )
        {
            this._compraService = compraService;
            this._usuarioRecomendacaoService = usuarioRecomendacaoService;
            this.sharedInfo = sharedInfo;
        }
        public async Task<Compra> GetAsync(int key)
        {
            return await _compraService.GetAsync(key);
        }

      
        public async Task<IList<ItemCompra>> GetListaComprasAsync()
        {
            var compras = await _compraService.GetListaCompras(sharedInfo.CodUsuario);
            return Mapper.Map<IList<ItemCompra>>(compras);
        }

        public async Task<Compra> PostCompraAsync(Compra compra)
        {
            //Comprador
            compra.GuidUsuario = sharedInfo.CodUsuario;
            compra.NomeComprador = sharedInfo.usuario.Name;
            compra.Cpf = sharedInfo.usuario.Cpf;
            compra.Celular = sharedInfo.usuario.Celular;
            compra.EmailComprador = sharedInfo.usuario.Email;
            //Venda
            compra.GuidCompra = Guid.NewGuid().ToString();
            compra.DataCompra = DateTime.Now;

            //temporario
            compra.CodStatus = 3;
            compra.DescricaoStatus = "Pre-aprovado";

        
        var retorno =  await _compraService.PostCompra(compra);
            await _usuarioRecomendacaoService.AddMovimentacaoAsync(new MovimentacaoVisita {
                usuario = sharedInfo.CodUsuario,
                evento = compra.ItemID.ToString(),
                status = "2"
            });
            return retorno;
        }
    }


}
