using AuthorizationServer.Domain.Interfaces.Repositories;
using AuthorizationServer.Domain.Interfaces.Service;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationServer.Domain.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.ReadAll();
        }
    }
}
