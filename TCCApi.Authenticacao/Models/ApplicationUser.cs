using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Models
{

    public class ApplicationUser : IdentityUser<int>
    {

        public IList<MyClaim> Claims { get; set; }

    }

    public class MyClaim : IdentityUserClaim<int>
    {
        public MyClaim()
        {

        }

        public MyClaim(string ClaimType, string ClaimValue)
        {
            this.ClaimType = ClaimType;
            this.ClaimValue = ClaimValue;
        }
    }



}
