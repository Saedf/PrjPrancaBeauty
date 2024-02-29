using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common.ExMethods;
using FrameWork.Domain.Contracts;
using FrameWork.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.Encrypt.Extensions;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Users
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(MainContext mainContext, UserManager<User> userManager, SignInManager<User> signInManager) : base(mainContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> CreateUserAsync(User entityUser, string password)
        {
            return await _userManager.CreateAsync(entityUser, password);
        }

        public async Task<IdentityResult> AddPhoneNumberPasswordAsync(User entity, string Password)
        {
            entity.PasswordPhoneNumber = Password.ToMD5();
            entity.LastTrySentSms = DateTime.Now;

            return await _userManager.UpdateAsync(entity);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User entityUser)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(entityUser);
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public bool RequireConfirmedEmail()
        {
            return _userManager.Options.SignIn.RequireConfirmedEmail;
        }

        public async Task<IdentityResult> EmailConfirmationAsync(User entityUser, string token)
        {
            if (entityUser == null)
                throw new ArgumentNullException("User cant be null.");

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException("Token cant be null.");

            return await _userManager.ConfirmEmailAsync(entityUser, token);
        }

        public  async Task<bool> IsEmailConfirmedAsync(User entityUser)
        {
            return await _userManager.IsEmailConfirmedAsync(entityUser);
        }

        public  async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }

        public async Task<string?> GetUserIdByUserNameAsync(string userName)
        {
            return await GetNoTraking.Where(a => a.UserName == userName).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }

        public  async Task<string?> GetUserIdByEmailAsync(string email)
        {
            return await GetNoTraking.Where(a => a.Email == email).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }
        public async Task<string?> GetUserIdByPhoneNumberAsync(string phoneNumber)
        {
            return await GetNoTraking.Where(a => a.PhoneNumber == phoneNumber).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }

        public async Task<IdentityResult> DeleteAsync(User entity)
        {
            return await _userManager.DeleteAsync(entity);
        }

        public async Task<User> FindByEmailAsync(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public async Task<IdentityResult> RemovePasswordAsync(User entity, string Password)
        {
            return await _userManager.AddPasswordAsync(entity, Password);
        }

        public async Task<IdentityResult> RemovePhoneNumberPasswordAsync(User entity)
        {
            entity.PasswordPhoneNumber = null;
            entity.LastTrySentSms = null;

            return await _userManager.UpdateAsync(entity);
        }

        public async Task<bool> HasPasswordAsync(User user)
        {
            return await _userManager.HasPasswordAsync(user);
        }
    }
}
