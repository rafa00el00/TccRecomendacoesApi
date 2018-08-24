using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Dados;
using TCCApi.CrudApi.Negocio;

namespace TCCApi.CrudApi.Utils
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
            services.AddScoped<IEventoDados, EventoDados>();
            services.AddScoped<IEmpresaDados, EmpresaDados>();
            services.AddScoped<IClienteDados, ClienteDados>();
            services.AddScoped<IVendaDados, VendaDados>();
        }

        private void InitializeNegocio(IServiceCollection services)
        {
            services.AddScoped<IEventoNegocio, EventoNegocio>();
            services.AddScoped<IEmpresaNegocio, EmpresaNegocio>();
            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            services.AddScoped<IVendaNegocio, VendaNegocio>();
        }

    }
}
