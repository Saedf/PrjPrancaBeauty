using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Repository.Users;
using PrancaBeauty.Infrastructure.LoggerPrj.SeriloggerPrj;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class Bootstrapper
    {
        public static void Config(this IServiceCollection services)
        {
            
            services.AddDbContext<MainContext>(opt => opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));
            services.AddScoped<ILogger, SeriloggerPrj>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
