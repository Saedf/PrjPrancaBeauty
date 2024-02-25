using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using FrameWork.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Users
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(MainContext mainContext, UserManager<User> userManager) : base(mainContext)
        {
            _userManager = userManager;
        }


        public async Task<IdentityResult> CreateUserAsync(User entityUser, string password)
        {
            return await _userManager.CreateAsync(entityUser, password);
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
    }
}
