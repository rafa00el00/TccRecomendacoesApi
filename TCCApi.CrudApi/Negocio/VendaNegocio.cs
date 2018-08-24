using TCCApi.CrudApi.Dados;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Negocio
{

    public interface IVendaNegocio : IGenericNegocio<Venda, VendaDTO>
    {

    }

    public class VendaNegocio : GenericNegocio<Venda, VendaDTO>, IVendaNegocio
    {


        public VendaNegocio(IVendaDados vendaDados) : base(vendaDados)
        {

        }


    }







}
