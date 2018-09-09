using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Models;
using TCCApi.FachadeApi.Services;

namespace TCCApi.FachadeApi.Negocio
{

    public class EmpresaNegocio : IEmpresaNegocio
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaNegocio(IEmpresaService empresaService)
        {
            this._empresaService = empresaService;
        }

        public async Task<Empresa> GetAsync(int id)
        {
            return await _empresaService.GetEmpresa(id);
        }

        public async Task PostAsync(Empresa empresa)
        {
            await _empresaService.PostEmpresa(empresa);
        }

       
    }


}
