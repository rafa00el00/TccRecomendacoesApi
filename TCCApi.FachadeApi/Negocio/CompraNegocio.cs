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

        public CompraNegocio(ICompraService compraService,IUsuarioRecomendacaoService usuarioRecomendacaoService)
        {
            this._compraService = compraService;
            this._usuarioRecomendacaoService = usuarioRecomendacaoService;
        }
        public async Task<Compra> GetAsync(int key)
        {
            return await _compraService.GetAsync(key);
        }

      
        public async Task<IList<ItemCompra>> GetListaComprasAsync()
        {
            return await _compraService.GetListaCompras(SharedInfo.CodUsuario);
        }

        public async Task<Compra> PostCompraAsync(Compra compra)
        {
            compra.GuidUsuario = SharedInfo.CodUsuario;
            var retorno =  await _compraService.PostCompra(compra);
            await _usuarioRecomendacaoService.AddMovimentacaoAsync(new MovimentacaoVisita {
                usuario = SharedInfo.CodUsuario,
                evento = compra.CodEvento.ToString(),
                status = "2"
            });
            return retorno;
        }
    }


}
