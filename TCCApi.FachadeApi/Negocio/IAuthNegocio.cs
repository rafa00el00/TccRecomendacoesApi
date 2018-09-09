using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;

namespace TCCApi.FachadeApi.Negocio
{
    public interface IAuthNegocio
    {
        Task<TokenResult> DoLoginUsuarioAsync(string email, string password);
        Task<TokenResult> DoLoginEmpresaAsync(string email, string password);
        Task<Usuario> GetUsuarioAsync();
        Task<Empresa> GetEmpresaAsync();
        Task<ApplicationUserTO> RegisterEmpresa(Empresa empresa);
        Task<ApplicationUserTO> RegisterUsuario(Usuario usuario);
    }
}