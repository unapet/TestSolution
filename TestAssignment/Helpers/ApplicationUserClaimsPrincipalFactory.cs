using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace TestApplication.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await  base.GenerateClaimsAsync(user);
            return identity;
        }
    }
}
