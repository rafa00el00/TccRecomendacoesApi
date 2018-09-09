using AutoMapper;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;
using TCCApi.FachadeApi.Services;

namespace TCCApi.FachadeApi.Negocio
{
    public class AuthNegocio : IAuthNegocio
    {
        private readonly IAuthService _authService;

        public AuthNegocio(IAuthService authService)
        {
            this._authService = authService;
        }

        public async Task<Usuario> GetUsuarioAsync()
        {
            var usuario = await _authService.GetUsuarioLogadoAsync();
            return usuario;
        }

        public async Task<Empresa> GetEmpresaAsync()
        {
            var empresa = await _authService.GetEmpresaLogadoAsync();
            return empresa;
        }

        public async Task<TokenResult> DoLoginUsuarioAsync(string email, string password)
        {
            var token = await _authService.DoLogin(email, password, "usuario");
            return token;
        }

        public async Task<TokenResult> DoLoginEmpresaAsync(string email, string password)
        {
            var token = await _authService.DoLogin(email, password, "empresa");
            return token;
        }

        public async Task<ApplicationUserTO> RegisterUsuario(Usuario usuario)
        {
            var user =  await _authService.PostUsuario(Mapper.Map<ApplicationUserTO>(usuario));
            return user;
        }

        public async Task<ApplicationUserTO> RegisterEmpresa(Empresa empresa)
        {
            return await _authService.PostEmpresa(Mapper.Map<ApplicationUserTO>(empresa));
        }
    }


}
