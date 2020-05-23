using AuthorizationServer.Domain.Interfaces.Repositories;
using AuthorizationServer.Domain.Interfaces.Service;
using AuthorizationServer.Domain.Services;
using AuthorizationServer.Infra.Memory.Repositories;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IClientRepository, ClientMemoryRepository>()
                .AddSingleton<IClientService, ClientService>()
                .BuildServiceProvider();

            var p = serviceProvider.GetService<IClientService>();
            var cs = (List<Client>) p.GetClients();

            cs.ForEach(o => Console.WriteLine(o.ClientId)); ;

            Console.WriteLine("Aperte qualquer coisa pra terminar");
            Console.ReadKey();
        }
    }
}
