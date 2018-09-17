using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TCCApi.VendaApi.Dados;
using TCCApi.VendaApi.Models;
using TCCApi.VendaApi.Negocio;
using TCCApi.VendaApi.Services;

namespace TCCApi.VendaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<MyDbContext>();
            services.AddScoped<DbContext, MyDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompraNegocio, CompraNegocio>();
            services.AddScoped<ICompraDados, CompraDados>();
            ConfigureAuthMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureAuthMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
            });
        }
    }
}
