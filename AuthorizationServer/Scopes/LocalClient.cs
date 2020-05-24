using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationServer.Scopes
{
    public class LocalClient
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
            new Client {
                ClientId = "SolidariedadeApi",
                ClientName = "Api's do sistema de gestão de solidariedade",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {
                    new Secret("solidariedadeMasterPwd".Sha256())},
                AllowedScopes = new List<string> { "SolidariedadeApi.read" }
            },
            new Client {
                ClientId = "SolidariedadeApp",
                ClientName = "Sistema de Gestão de Solidariedade",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "SolidariedadeApi.write"
                },
                RedirectUris = new List<string> {"https://localhost:44330/signin-oidc"},
                PostLogoutRedirectUris = new List<string> {"https://localhost:44330"}
            }
        };
        }
    }
}
