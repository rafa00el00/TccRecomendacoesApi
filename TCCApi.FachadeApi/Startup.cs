using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TCCApi.FachadeApi.Middleware;
using TCCApi.FachadeApi.Utils;
using TCCApi.RecomendacoesApi.Utils;

namespace TCCApi.FachadeApi
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
            services.AddMvc(opts =>
            {
                opts.Filters.Add<GetUsuarioMiddleware>();
            });

            //Iniciando o IOC
            new IocFactory().Initialize(services);
            new MapperFactory();
            services.AddSingleton<IConfiguration>(Configuration);

            var authUrl = Configuration.GetSection("apisUrls:AUTHAPI:url").Get<string>();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                 options.Authority = authUrl;
                 options.ApiName = "api1";
             });

            services.AddCors(config =>
            {
                config.AddPolicy("default",
                    cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors("default");
            


        }
    }
}
