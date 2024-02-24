using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Application.Services.Email;
using FrameWork.Infrastructure;
using PrancaBeauty.Application.Apps.Templates;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Repository.Templates;
using PrancaBeauty.Infrastructure.EfCore.Repository.Users;
using PrancaBeauty.Infrastructure.LoggerPrj.SeriloggerPrj;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class Bootstrapper
    {
        public static void Config(this IServiceCollection services)
        {
            
            services.AddDbContext<MainContext>(opt => opt.UseSqlServer("Data Source=.; Initial Catalog=PrancaBeautyDB; Integrated Security=true; User Id=sa; Password=123456; TrustServerCertificate=True"));
            services.AddScoped<ILogger, SeriloggerPrj>();
            services.AddScoped<IEmailSender, GmailSender>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITemplateApplication, TemplateApplication>();

        }
    }
}
