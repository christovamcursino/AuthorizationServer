using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationServer.Domain.Interfaces.Repositories;
using AuthorizationServer.Domain.Interfaces.Service;
using AuthorizationServer.Domain.Services;
using AuthorizationServer.Infra.Memory.Repositories;
using AuthorizationServer.Scopes;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthorizationServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IClientRepository, ClientMemoryRepository>()
                    .AddSingleton<IClientService, ClientService>();

            //var sp = services.BuildServiceProvider();
            //IClientService cs = sp.GetService<IClientService>();

            services.AddIdentityServer()
                .AddInMemoryClients(LocalClient.Get())
                .AddInMemoryIdentityResources(LocalResources.GetIdentityResources())
                .AddInMemoryApiResources(LocalResources.GetApiResources())
                .AddTestUsers(LocalUser.Get())
                .AddDeveloperSigningCredential();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
            


            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/
        }
    }
}
