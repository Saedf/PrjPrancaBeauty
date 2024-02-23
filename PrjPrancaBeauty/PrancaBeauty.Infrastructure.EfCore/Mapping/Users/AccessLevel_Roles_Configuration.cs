using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Infrastructure.EfCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class AccessLevel_Roles_Configuration : IEntityTypeConfiguration<AccessLevel_Roles>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<AccessLevel_Roles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasMaxLength(150);
            builder.Property(x => x.AccessLevelId).IsRequired().HasMaxLength(150);
            builder.Property(x => x.RoleId).IsRequired().HasMaxLength(450);

            builder.HasOne(a => a.AccessLevels)
                .WithMany(a => a.AccessLevelRoles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.AccessLevelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Roles)
                .WithMany(a => a.AccessLevelRoles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
