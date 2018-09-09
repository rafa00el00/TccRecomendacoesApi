using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCCApi.Authenticacao.Dados;
using TCCApi.Authenticacao.Negocio;

namespace TCCApi.Authenticacao.Utils
{
    public class IocFactory
    {

        public void Initialize(IServiceCollection services)
        {
            InitializeDB(services);
            InitializeNegocio(services);
        }

        private void InitializeDB(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
            services.AddScoped<DbContext, MyDbContext>();
            services.AddScoped<IUsuarioDados, UsuarioDados>();
            services.AddScoped<IApplicationUserDados, ApplicationUserDados>();
            
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            
        }

    }
}
