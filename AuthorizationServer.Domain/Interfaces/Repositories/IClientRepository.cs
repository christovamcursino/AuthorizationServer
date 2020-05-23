using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationServer.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);
        IEnumerable<Client> ReadAll();
        Client ReadById(String clientId);
        void Update(Client product);
        void Delete(String clientId);
        void SaveChanges();
    }
}
