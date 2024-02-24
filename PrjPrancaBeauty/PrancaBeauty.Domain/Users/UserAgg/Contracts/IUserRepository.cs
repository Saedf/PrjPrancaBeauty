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

    }
}
