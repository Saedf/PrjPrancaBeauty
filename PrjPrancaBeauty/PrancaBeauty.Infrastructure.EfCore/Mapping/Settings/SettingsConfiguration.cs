using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Infrastructure.EfCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Settings.SettingsAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Settings
{
    public class SettingsConfiguration : IEntityTypeConfiguration<Setting>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.SiteUrl).IsRequired().HasMaxLength(100);
            builder.Property(a => a.SiteTitle).IsRequired().HasMaxLength(100); ;
            builder.Property(a => a.SiteDescription).IsRequired().HasMaxLength(100); ;
            builder.Property(a => a.Sitemail).IsRequired().HasMaxLength(100); ;
            builder.Property(a => a.SitePhoneNumber).IsRequired().HasMaxLength(25); ;

            builder.HasOne(x => x.Language)
                .WithMany(a => a.Settinges)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(z => z.LangId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
