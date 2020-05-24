using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationServer.Scopes
{
    public class LocalResources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
            new ApiResource {
                Name = "SolidariedadeApi",
                DisplayName = "Recurso da api de solidariedade",
                Description = "Recurso da api de solidariedade",
                UserClaims = new List<string> {"role"},
                ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                Scopes = new List<Scope> {
                    new Scope("SolidariedadeApi.read"),
                    new Scope("SolidariedadeApi.write")
                }
            }
        };
        }
    }
}
