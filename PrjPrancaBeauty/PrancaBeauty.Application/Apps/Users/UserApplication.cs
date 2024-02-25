using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Application.Apps.AccessLevels;
using PrancaBeauty.Application.Contracts.Results;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Application.Apps.Users
{
    public class UserApplication: IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;   
        private readonly IAccesslevelApplication _accesslevelApplication;
        public UserApplication(IUserRepository userRepository, ILogger logger, IAccesslevelApplication accesslevelApplication)
        {
            _userRepository = userRepository;
            _logger = logger;
            _accesslevelApplication = accesslevelApplication;
        }


        public async Task<OperationResult> AddUserAsync(InpAddUser addUser)
        {
            try
            {
                User user = new()
                {
                    Date = DateTime.Now,
                    Email = addUser.Email,
                    FirstName = addUser.FirstName,
                    LastName = addUser.LastName,
                    AccessLevelId =Guid.Parse(await _accesslevelApplication.GetIdByNameAsync("Users")),
                    IsActive = true,
                    PhoneNumber = addUser.PhoneNumber,
                    UserName = addUser.Email
                };
                var result = await _userRepository.CreateUserAsync(user, addUser.Password);
                if (result.Succeeded)
                {
                    if (_userRepository.RequireConfirmedEmail())
                        return new OperationResult().Succeeded(1, user.Id.ToString());
                    else
                        return new OperationResult().Succeeded("UserCreatedSuccessfully");
                }
                else
                {
                    return new OperationResult().Failed(string.Join(", ", result.Errors.Select(a => a.Description)));
                }
            }
            catch (Exception ex)
            {
              _logger.Error(ex);
              return new OperationResult().Failed("Error500");
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(InpGenerateEmailConfirmationToken Input)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                var qUser = await _userRepository.FindByIdAsync(Input.UserId);

                return await _userRepository.GenerateEmailConfirmationTokenAsync(qUser);
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _logger.Debug(ex);
            //    return null;
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<OperationResult> EmailConfirmationAsync(string userId, string token)
        {
            try
            {
                #region Validations
                // Input.CheckModelState(_ServiceProvider);
                #endregion

                if (await IsEmailConfirmedAsync(userId))
                    return new OperationResult().Failed("EmailAlreadyVerified");


                var qUser = await _userRepository.FindByIdAsync(userId);

                var Result = await _userRepository.EmailConfirmationAsync(qUser, token);
                if (Result.Succeeded)
                {
                    return new OperationResult().Succeeded("EmailConfirmationSuccessfully");
                }
                else
                {
                    return new OperationResult().Failed(string.Join(", ", Result.Errors.Select(a => a.Description)));
                }
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _logger.Debug(ex);
            //    return new OperationResult().Failed(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }

        }

        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var qUser = await _userRepository.FindByIdAsync(userId);

            return await _userRepository.IsEmailConfirmedAsync(qUser);
        }
    }
}
