using Microsoft.AspNetCore.Identity;

namespace MessageApp.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(string username, string password);
        Task<SignInResult> PasswordSignIn(string username, string password);
        Task SignOut();
    }
}
