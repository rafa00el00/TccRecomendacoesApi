using TCCApi.Authenticacao.Dados;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Negocio
{

    public interface IEmpresaNegocio : IGenericNegocio<Empresa, EmpresaDTO>
    {

    }
    public class EmpresaNegocio : GenericNegocio<Empresa, EmpresaDTO>, IEmpresaNegocio
    {
        public EmpresaNegocio(IEmpresaDados dados) : base(dados)
        {
        }
    }


}
