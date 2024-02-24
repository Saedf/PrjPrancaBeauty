using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Contracts;
using System.Security.Principal;

namespace PrancaBeauty.Infrastructure.EfCore.Context
{
    public class MainContext:IdentityDbContext<User,Role,Guid>
    {
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
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


            var entitiesConfAssembly = typeof(IEntityConf).Assembly;
            builder.RegisterEntityTypeConfiguration(entitiesConfAssembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=PrancaBeautyDB; Integrated Security=true; User Id=sa; Password=123456; TrustServerCertificate=True");
        }
    }
}
