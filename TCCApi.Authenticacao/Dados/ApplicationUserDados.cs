using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCApi.Authenticacao.Models;

namespace TCCApi.Authenticacao.Dados
{

    public interface IApplicationUserDados
    {
        Task<ApplicationUser> AddAsync(ApplicationUser applicationUser, string password);
    }
    public class ApplicationUserDados : IApplicationUserDados
    {
        private readonly MyDbContext _myDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserDados(MyDbContext myDbContext, UserManager<ApplicationUser> userManager)
        {
            this._myDbContext = myDbContext;
            this._userManager = userManager;
            _myDbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            
        }
        public virtual async Task<ApplicationUser> AddAsync(ApplicationUser applicationUser,string password)
        {
            var claimToRemove = applicationUser.Claims.FirstOrDefault(c => c.ClaimType == "datacriacao");
            applicationUser.Claims.Remove(claimToRemove);
            applicationUser.Claims.Add(new MyClaim("datacriacao", DateTime.Now.ToString("yyyy-MM-dd")));
            var user = await _userManager.CreateAsync(applicationUser, password);
            if (user.Succeeded)
            {
                applicationUser.Claims.Add(new MyClaim("codempresa", applicationUser.Id.ToString()));
                await _userManager.AddClaimsAsync(applicationUser, applicationUser.Claims.Select(u => new Claim(u.ClaimType, u.ClaimValue)));

            }
            else
            {
                throw new Exception(user.Errors.Select(e => e.Description).FirstOrDefault());
            }

            return applicationUser;

            //await _myDbContext.AddAsync<ApplicationUser>(applicationUser);

            //await _myDbContext.SaveChangesAsync();
            //return applicationUser;
        }
    }




}
