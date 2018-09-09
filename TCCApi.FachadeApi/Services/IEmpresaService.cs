using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Models;

namespace TCCApi.FachadeApi.Services
{
    public interface IEmpresaService
    {
        string BaseUrl { get; }

        Task<Empresa> GetEmpresa(int id);
        Task PatchEmpresa(Empresa empresa);
        Task PostEmpresa(Empresa empresa);
    }
}