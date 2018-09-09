using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace TCCApi.Authenticacao.IdentityConfiguration
{
    public class IdentityTestUsersConfig
    {
        

public static List<TestUser> GetUsers()
    {
        return new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password",

            Claims = new List<Claim>
            {
                new Claim("name","Alice"),
                new Claim("email","alice@bob.com"),
                new Claim("codEmpresa","1"),

            }
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password",

            Claims = new List<Claim>
            {
                new Claim("name","Bob"),
                new Claim("email","bob@bob.com"),
                new Claim("guidUsuario", Guid.NewGuid().ToString()),
                new Claim("role","admin"),
                new Claim("role","usuario")

            }
        }
    };
    }
}
}
