using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.Results;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Application.Apps.Users
{
    public interface IUserApplication
    {
        Task<OperationResult> AddUserAsync(InpAddUser addUser);
        Task<string> GenerateEmailConfirmationTokenAsync(InpGenerateEmailConfirmationToken Input);
        Task<OperationResult> EmailConfirmationAsync(string userId,string token);
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task<OperationResult> LoginByUserNamePasswordAsync(string userName, string  password);
        Task<OperationResult> LoginAsync(string userId, string password);
        Task<OutGetAllUserDetails> GetAllUserDetailsAsync(string userId);
        Task<bool> RemoveUnConfirmedUserAsync(string Email);
        Task<User> GetUserByEmailAsync(string Email);

    }
}
