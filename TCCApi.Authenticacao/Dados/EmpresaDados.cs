using Microsoft.EntityFrameworkCore;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Dados
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
