﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class UserConfiguration:IEntityTypeConfiguration<Domain.Users.UserAgg.Entities.User>,IEntityConf
    {
        public void Configure(EntityTypeBuilder<Domain.Users.UserAgg.Entities.User> builder)
        {
            builder.Property(a => a.Id);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.AccessLevel)
                .WithMany(a => a.Users)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.AccessLevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
