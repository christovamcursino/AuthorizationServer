using AuthorizasionServer.Utils;
using AuthorizationServer.Domain.Interfaces.Repositories;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static IdentityModel.OidcConstants;

namespace AuthorizationServer.Infra.Memory.Repositories
{
    public class ClientMemoryRepository : IClientRepository
    {
        private List<Client> _clientes;

        public ClientMemoryRepository()
        {
            _clientes = new List<Client> {
                new Client {
                    ClientId = "sistemaSolidariedade",
                    ClientName = "Sistema de Solidariedade",
                    AllowedGrantTypes = { GrantTypes.ClientCredentials },
                    ClientSecrets = new List<Secret> {
                        new Secret(Utils.sha256_hash("superSecretPassword"))},
                    AllowedScopes = new List<string> { "customAPI.read" } } };
        }


        public void Create(Client client)
        {
            _clientes.Add(client);
        }

        public void Delete(string clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> ReadAll()
        {
            return _clientes;
        }

        public Client ReadById(string clientId)
        {
            return _clientes.Find(o => o.ClientId.Equals(clientId));
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Client product)
        {
            throw new NotImplementedException();
        }
    }
}
