using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Application.Services.Email;
using FrameWork.Common.Utilities.Downloader;
using FrameWork.Infrastructure;
using PrancaBeauty.Application.Apps.AccessLevels;
using PrancaBeauty.Application.Apps.AccesslevelsRoles;
using PrancaBeauty.Application.Apps.Templates;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Domain.Settings.SettingsAgg.Contracts;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Contracts;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel;
using PrancaBeauty.Infrastructure.EfCore.Repository.Settings;
using PrancaBeauty.Infrastructure.EfCore.Repository.Templates;
using PrancaBeauty.Infrastructure.EfCore.Repository.Users;
using PrancaBeauty.Infrastructure.LoggerPrj.SeriloggerPrj;
using PrancaBeauty.Application.Apps.Settings;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class Bootstrapper
    {
        public static void Config(this IServiceCollection services)
        {
            
            services.AddDbContext<MainContext>(opt => opt.UseSqlServer("Data Source=.; Initial Catalog=PrancaBeautyDB; Integrated Security=true; User Id=sa; Password=123456; TrustServerCertificate=True"));
            services.AddScoped<ILogger, SeriloggerPrj>();
            services.AddScoped<IEmailSender, GmailSender>();
            services.AddScoped<IDownloader, Downloader>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IAccesslevelRepository, AccessLevelRepository>();
            services.AddScoped<IAccesslevelRolesRepository, AccesslevelRolesRepository>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITemplateApplication, TemplateApplication>();
            services.AddScoped<ISettingApplication, SettingApplication>();
            services.AddScoped<IAccesslevelApplication, AccesslevelApplication>();
            services.AddScoped<IAccesslevelRolesApplication, AccesslevelRolesApplication>();

        }
    }
}
