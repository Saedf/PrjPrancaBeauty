using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class IdentityConfig
    {
        public static IdentityBuilder AddCustomIdentity(this IServiceCollection services)
        {
            return services.AddIdentity<TblUser, TblRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = true;
                    opt.SignIn.RequireConfirmedEmail=true;
                    opt.SignIn.RequireConfirmedPhoneNumber=true;

                    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                    opt.User.RequireUniqueEmail=true;

                    opt.Password.RequireDigit=true;
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredUniqueChars = 0;   

                    opt.Lockout.AllowedForNewUsers=true;
                    opt.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 15, 0);
                    opt.Lockout.MaxFailedAccessAttempts = 3;

                }).AddEntityFrameworkStores<MainContext>()
                .AddDefaultTokenProviders() ;
        }
    }
}
