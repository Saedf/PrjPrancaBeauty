using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Context
{
    public class MainContext:IdentityDbContext<Users>
    {
        public MainContext(DbContextOptions<MainContext> options):base(options)
        {
            
        }
    }
}
