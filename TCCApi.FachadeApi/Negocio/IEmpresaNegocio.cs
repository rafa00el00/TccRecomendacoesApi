using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Negocio
{
    public interface IEmpresaNegocio
    {
        Task<Empresa> GetAsync(int id);
        Task PostAsync(Empresa empresa);
    }
}