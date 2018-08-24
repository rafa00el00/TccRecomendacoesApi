using TCCApi.CrudApi.Dados;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Negocio
{

    public interface IEmpresaNegocio : IGenericNegocio<Empresa, EmpresaDTO>
    {

    }

    public class EmpresaNegocio : GenericNegocio<Empresa, EmpresaDTO>, IEmpresaNegocio
    {


        public EmpresaNegocio(IEmpresaDados empresaDados) : base(empresaDados)
        {

        }


    }




}
