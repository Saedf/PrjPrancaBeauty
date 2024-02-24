using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.Results;
using PrancaBeauty.Application.Contracts.Users;

namespace PrancaBeauty.Application.Apps.Users
{
    public interface IUserApplication
    {
        Task<OperationResult> AddUserAsync(InpAddUser addUser);
        Task<string> GenerateEmailConfirmationTokenAsync(InpGenerateEmailConfirmationToken Input);
    }
}
