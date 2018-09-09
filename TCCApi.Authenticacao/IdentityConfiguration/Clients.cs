using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TCCApi.Authenticacao.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "service.client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        IdentityServerConstants.StandardScopes.Email,
        IdentityServerConstants.StandardScopes.Phone,
        IdentityServerConstants.StandardScopes.Address,

                    "api1", "api2.full_access" , "usuario.profile", "empresa.profile" }
            }
        };
        }
    }
}
