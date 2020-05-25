using System.Reflection;
using AuthorizationServer.Domain.Interfaces.Repositories;
using AuthorizationServer.Domain.Interfaces.Service;
using AuthorizationServer.Domain.Services;
using AuthorizationServer.Infra.Memory.Repositories;
using AuthorizationServer.Scopes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using IdentityServer4.EntityFramework.DbContexts;
using System.Linq;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AuthorizationServer.DbInitializer;
using IdentityServer4;

namespace AuthorizationServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            const string connectionString = @"Server = localhost; Database = dbauthenticator; User = oauth; Password = oauth;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddSingleton<IClientRepository, ClientMemoryRepository>()
                    .AddSingleton<IClientService, ClientService>();

            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseMySql(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly)
                                      .ServerVersion(new Version(8, 0, 19), ServerType.MySql)));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                //.AddInMemoryClients(LocalClient.Get())
                //.AddInMemoryIdentityResources(LocalResources.GetIdentityResources())
                //.AddInMemoryApiResources(LocalResources.GetApiResources())
                //.AddTestUsers(LocalUser.Get())
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseMySql(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly)
                                      .ServerVersion(new Version(8, 0, 19), ServerType.MySql));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseMySql(connectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly)
                                      .ServerVersion(new Version(8, 0, 19), ServerType.MySql));

                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddAspNetIdentity<IdentityUser>(
                    
                );
            //Google


            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitDB.InitializeDbTestData(app);

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
