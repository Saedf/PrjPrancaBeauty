using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Domain.Users.UserAgg.Contracts
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IdentityResult> CreateUserAsync(User entityUser, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(User entityUser);
        Task<User> FindByIdAsync(string userId);
        bool RequireConfirmedEmail();
        Task<IdentityResult> EmailConfirmationAsync(User entityUser, string token);
        Task<bool> IsEmailConfirmedAsync(User entityUser);
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
        Task<string?> GetUserIdByUserNameAsync(string userName);
        Task<string?> GetUserIdByEmailAsync(string email);
        Task<string?> GetUserIdByPhoneNumberAsync(string phoneNumber);
        Task<IdentityResult> DeleteAsync(User entity);
    }
}
