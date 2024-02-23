using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class AccessLevelConfiguration:IEntityTypeConfiguration<AccessLevel>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<AccessLevel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
