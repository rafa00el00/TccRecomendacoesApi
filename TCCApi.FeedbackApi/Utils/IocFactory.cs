using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCCApi.FeedbackApi.Dados;
using TCCApi.FeedbackApi.Negocio;

namespace TCCApi.FeedbackApi.Utils
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
            services.AddScoped<IFeedbackDados, FeedbackDados>();
            
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IFeedbackNegocio, FeedbackNegocio>();
            
        }

    }
}
