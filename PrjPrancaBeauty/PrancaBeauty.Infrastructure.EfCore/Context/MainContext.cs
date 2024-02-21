using FrameWork.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

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
            var entityAssembly=typeof(IEntityConf).Assembly;
            builder.RegisterAllEntities<IEntity>(entityAssembly);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
        }
    }
}
