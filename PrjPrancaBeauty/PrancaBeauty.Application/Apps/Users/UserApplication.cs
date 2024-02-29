using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Application.Consts;
using FrameWork.Common.ExMethods;
using FrameWork.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public async Task<OperationResult> LoginByUserNamePasswordAsync(string userName, string password)
        {
            try
            {
                #region Validations
                // Input.CheckModelState(_ServiceProvider);
                #endregion
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException("UserId cant be null.");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("Password cant be null.");
                var userId = await _userRepository.GetUserIdByUserNameAsync(userName);

                if (userId == null)
                    return new OperationResult().Failed("UserNameOrPasswordIsInvalid");

                return await LoginAsync(userId, password);
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return new OperationResult().Failed(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OutGetAllUserDetails> GetAllUserDetailsAsync(string userId)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                var qData = await _userRepository.Get
                    .Where(a => a.Id == Guid.Parse(userId))
                    .Select(a => new OutGetAllUserDetails
                    {
                        Id = a.Id.ToString(),
                      //  SellerId = a.tblSellers != null ? a.tblSellers.Id.ToString() : null,
                        UserName = a.UserName,
                        Email = a.Email,
                        PhoneNumber = a.PhoneNumber,
                        AccessLevelId = a.AccessLevelId.ToString(),
                        AccessLevelTitle = a.AccessLevel.Name,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Date = a.Date,
                        IsActive = a.IsActive
                    })
                    .SingleOrDefaultAsync();

                if (qData == null)
                    return null;

                return qData;
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return null;
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<bool> RemoveUnConfirmedUserAsync(string Email) 
        {
            var qUser = await GetUserByEmailAsync(Email);
            if (qUser == null)
                return true;

            if (qUser.EmailConfirmed)
                return true;

           var result = await _userRepository.DeleteAsync(qUser);
            if (result.Succeeded)
                return true;
            else
                throw new Exception(string.Join(", ", result.Errors.Select(a => a.Description)));
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            // throw new NotImplementedException();
            var qUser = await _userRepository.FindByEmailAsync(Email);
            return qUser;
        }

        public async Task<OperationResult> LoginByEmailLinkStep1Async(string Email, string IP)
        {
            try
            {
                #region Validations
              //  Input.CheckModelState(_ServiceProvider);
                #endregion

                var qUser = await GetUserByEmailAsync(Email);

                if (qUser == null)
                    return new OperationResult().Failed("EmailNotFound");

                if (qUser.EmailConfirmed == false)
                    return new OperationResult().Failed("PleaseConfirmYourEmail");

                if (qUser.IsActive == false)
                    return new OperationResult().Failed("YourAccountIsDisabled");

                var ReNewPasswordResult = await ReCreatePasswordAsync( qUser.Id.ToString() );
                if (ReNewPasswordResult.IsSucceeded)
                {
                    return new OperationResult().Succeeded(qUser.Id + ", " + ReNewPasswordResult.Message + ", " + IP + ", " + DateTime.Now.ToString("yy/MM/dd HH:mm"));
                }
                else
                {
                    return new OperationResult().Failed(ReNewPasswordResult.Message);
                }
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return new OperationResult().Failed(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }

        }

        public async Task<OperationResult> LoginByEmailLinkStep2Async(string UserId, string Password, string LinkIP, string UserIP, DateTime dateTime)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                var qUser = await _userRepository.FindByIdAsync(UserId);

                if (qUser == null)
                    return new OperationResult().Failed("LinkExipred");

                if (qUser.EmailConfirmed == false)
                    return new OperationResult().Failed("LinkExipred");

                if (qUser.IsActive == false)
                    return new OperationResult().Failed("YourAccountIsDisabled");

                if (qUser.PasswordPhoneNumber != Password.ToMD5())
                    return new OperationResult().Failed("LinkExipred");

                return new OperationResult().Succeeded(qUser.Id.ToString());
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return new OperationResult().Failed(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> ReCreatePasswordAsync(string userId)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                var qUser = await _userRepository.GetById(default, userId);
                if (qUser == null)
                    return new OperationResult().Failed("User not found");

                if (qUser.LastTrySentSms.HasValue)
                    if (qUser.LastTrySentSms.Value.AddMinutes(AuthConst.LimitToResendSmsInMinute) > DateTime.Now)
                        return new OperationResult().Failed("LimitToResendSms2Minute");

                #region حذف پسورد قبلی کاربر
                var Result = await _userRepository.RemovePhoneNumberPasswordAsync(qUser);
                if (!Result.Succeeded)
                {
                    _logger.Error(string.Join(", ", Result.Errors.Select(a => a.Description)));
                    return new OperationResult().Failed("UserNotFound");
                }
                #endregion

                #region تنظیم پسورد جدید برای کاربر
                string NewPassword = new Random().Next(10000, 99999).ToString();
                var AddPassResult = await _userRepository.AddPhoneNumberPasswordAsync(qUser, NewPassword);
                if (!AddPassResult.Succeeded)
                {
                    _logger.Error(string.Join(", ", AddPassResult.Errors.Select(a => a.Description)));
                    return new OperationResult().Failed("UserNotFound");
                }
                #endregion

                return new OperationResult().Succeeded(NewPassword);
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return new OperationResult().Failed(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> LoginAsync(string userId, string password)
        {
            try
            {
                #region Validations
                //Input.CheckModelState(_ServiceProvider);
                #endregion

                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentNullException("UserId cant be null.");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("Password cant be null.");

                var qUser = await _userRepository.FindByIdAsync(userId);

                if (qUser == null)
                    return new OperationResult().Failed("UserNameOrPasswordIsInvalid");

                if (qUser.EmailConfirmed == false)
                    return new OperationResult().Failed("PleaseConfirmYourEmail");

                if (qUser.IsActive == false)
                    return new OperationResult().Failed("YourAccountIsDisabled");

                var Result = await _userRepository.PasswordSignInAsync(qUser, password, true, true);
                if (Result.Succeeded)
                {
                    return new OperationResult().Succeeded(qUser.Id.ToString());
                }
                else
                {
                    if (Result.IsLockedOut)
                        return new OperationResult().Failed("UserIsLockedOut");
                    else if (Result.IsNotAllowed)
                        return new OperationResult().Failed("UserNameOrPasswordIsInvalid");
                    else
                        return new OperationResult().Failed("UserNameOrPasswordIsInvalid");
                }
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
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
