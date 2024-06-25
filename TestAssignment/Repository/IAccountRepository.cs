using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TestApplication.Models;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace TestApplication.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityUser> GetUserByEmailAsync(string email);

        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel model);

        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        Task GenerateEmailConfirmationTokenAsync(IdentityUser user);

        Task GenerateForgotPasswordTokenAsync(IdentityUser user);

        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}