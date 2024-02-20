using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Context
{
    public class MainContext:IdentityDbContext<Users,Roles,Guid>
    {
        public MainContext(DbContextOptions<MainContext> options):base(options)
        {
            
        }

        public MainContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
