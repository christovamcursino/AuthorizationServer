using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationServer.Domain.Interfaces.Service
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
    }
}
