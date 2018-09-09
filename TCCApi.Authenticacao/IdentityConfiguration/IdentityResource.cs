using IdentityServer4.Models;
using System.Collections.Generic;
using static IdentityServer4.Models.IdentityResources;

namespace TCCApi.Authenticacao.IdentityConfiguration
{



    public class IdentityResourceConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var customProfile = new IdentityResource(
             name: "usuario.profile",
            displayName: "Custom profile",
            claimTypes: new[] {
                    "name",
                    "guidusuario",
                    "email",
                    "status",
                    "datacriacao",
                    "cpf",
                    "tags",
                    "telefone",
                    "celular",
                    "datanascimento",
                    "tipo"
            });
            var EmpresaProfile = new IdentityResource(
            name: "empresa.profile",
           displayName: "Empresa profile",
           claimTypes: new[] {
                    "name",
                    "codEmpresa",
                    "email",
                    "razaosocial",
                    "datacriacao",
                    "cnpj",
                    "telefonecontato",
                    "organizador",
                    "tipo"
            });

            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                 new IdentityResources.Profile(),
             new IdentityResources.Phone(),
                new IdentityResources.Address(),
                customProfile,
                EmpresaProfile
            };
        }
    }
}
