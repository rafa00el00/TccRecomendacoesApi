using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;

namespace TCCApi.FachadeApi.Services
{
    public interface IAuthService
    {
        string BaseUrl { get; }

        Task<TokenResult> DoLogin(string email, string password, string type);
        Task<Usuario> GetUsuarioLogadoAsync();
        Task<Empresa> GetEmpresaLogadoAsync();
        Task<ApplicationUserTO> PostEmpresa(ApplicationUserTO compra);
        Task<ApplicationUserTO> PostUsuario(ApplicationUserTO compra);
    }
}