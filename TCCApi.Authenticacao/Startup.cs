using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TCCApi.Authenticacao.Dados;
using TCCApi.Authenticacao.IdentityConfiguration;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Util.MappersProfile;
using TCCApi.Authenticacao.Utils;

namespace TCCApi.Authenticacao
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
            services.AddMvc();
            new IocFactory().Initialize(services);
            var builder = services.AddIdentityServer();
            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultTokenProviders();

            builder.AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityResourceConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityApiResourceConfig.GetApiResources())
                .AddInMemoryClients(Clients.Get())
                .AddAspNetIdentity<ApplicationUser>();
                //.AddTestUsers(IdentityTestUsersConfig.GetUsers());


            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DatabaseProfile>();
                cfg.CreateMissingTypeMaps = true;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
