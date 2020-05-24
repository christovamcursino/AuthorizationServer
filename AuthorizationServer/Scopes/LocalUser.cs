using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationServer.Scopes
{
    public class LocalUser
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
            new TestUser {
                SubjectId = "d7fdb8d6-4bcb-4821-a58f-e86601a0c220",
                Username = "christo",
                Password = "christopwd",
                Claims = new List<Claim> {
                    new Claim(JwtClaimTypes.Email, "christovamcursino@al.infnet.edu.br"),
                    new Claim(JwtClaimTypes.Role, "admin")
                }
            }
        };
        }
    }
}
