
using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TCCApi.Authenticacao.IdentityConfiguration
{
    public class IdentityApiResourceConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
    {
        new ApiResource()
        {
            Name= "api1",
            // secret for using introspection endpoint
            ApiSecrets =
            {
                new Secret("secret".Sha256())
            },
             
            // include the following using claims in access token (in addition to subject id)
            UserClaims = {
                JwtClaimTypes.Name,
                JwtClaimTypes.Email,

            }
        }
    };
        }
    }
}
