using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Infrastructure.EfCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Roles
{
    public class RoleConfiguration : IEntityTypeConfiguration<Domain.Users.RoleAgg.Entities.TblRole>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<Domain.Users.RoleAgg.Entities.TblRole> builder)
        {
            builder.Property(a => a.ParentId).IsRequired(false).HasMaxLength(450);
            builder.Property(a => a.PageName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(500);

           
        }

    }
}
