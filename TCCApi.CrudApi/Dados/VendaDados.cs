using Microsoft.EntityFrameworkCore;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{

    public interface IVendaDados: IGenericDados<VendaDTO>
    {

    }

    public class VendaDados : GenericDados<VendaDTO>, IVendaDados
    {

        public VendaDados(DbContext context) : base(context)
        {
        }

    }

}
