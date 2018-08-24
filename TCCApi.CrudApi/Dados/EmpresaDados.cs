using Microsoft.EntityFrameworkCore;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{

    public interface IEmpresaDados : IGenericDados<EmpresaDTO>
    {

    }

    public class EmpresaDados : GenericDados<EmpresaDTO>, IEmpresaDados
    {

        public EmpresaDados(DbContext context) : base(context)
        {
        }

    }

}
