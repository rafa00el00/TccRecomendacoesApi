using System;
using System.Collections.Generic;

namespace TCCApi.FachadeApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string Cpf { get; set; }
        public IList<string> Tags { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string GuidUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Password { get; set; }
        public string Tipo { get; set; }

    }

    public class ApplicationUserTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IList<MyClaim> Claims { get; set; }

        public static IList<MyClaim> CreateClaimsFrom<T>(T objeto) where T : class
        {
            var claims = new List<MyClaim>();

            foreach (var prp in objeto.GetType().GetProperties())
            {
                if (prp.Name.ToUpper().Equals("PASSWORD") || prp.GetValue(objeto) == null)
                    continue;

                if(prp.PropertyType.Name.Equals("DateTime"))
                {
                    claims.Add(new MyClaim(prp.Name.ToLower(), ((DateTime)prp.GetValue(objeto)).ToString("yyyy-MM-dd")));
                }
                else if (prp.PropertyType.Name.ToUpper().Equals("IList`1".ToUpper()))
                {
                    var itens = (IList<string>)prp.GetValue(objeto);
                    foreach (var item in itens)
                    {
                        claims.Add(new MyClaim(prp.Name.ToLower(), item));
                    }
                }
                else
                {
                    claims.Add(new MyClaim(prp.Name.ToLower(), prp.GetValue(objeto).ToString()));

                }
            }


            return claims;
        }
    }

    public class MyClaim 
    {
        public MyClaim()
        {

        }

        public MyClaim(string ClaimType, string ClaimValue)
        {
            this.ClaimType = ClaimType;
            this.ClaimValue = ClaimValue;
        }

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    public class TokenResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }

    }


}
