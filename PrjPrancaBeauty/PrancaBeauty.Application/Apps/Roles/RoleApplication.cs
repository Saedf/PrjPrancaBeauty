using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Domain.Users.RoleAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Application.Apps.Roles
{
    public class RoleApplication:IRoleApplication
    {
        private readonly ILogger _Logger; 
       // private readonly ILocalizer _Localizer;
        //private readonly IServiceProvider _ServiceProvider;
        private readonly IRoleRepository _RoleRepository;
        private readonly RoleManager<Role> _RoleManager;
        private readonly UserManager<User> _UserManager;

        public RoleApplication(ILogger logger, IRoleRepository roleRepository, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _Logger = logger;
            _RoleRepository = roleRepository;
            _RoleManager = roleManager;
            _UserManager = userManager;
        }

        public async Task<List<string>> GetRolesByUserAsync(string userId)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                var qUser = await _UserManager.FindByIdAsync(userId);
                if (qUser == null)
                    return null;

                return (await _UserManager.GetRolesAsync(qUser)).ToList();
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return null;
            //}
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return null;
            }
        }
    }
}
