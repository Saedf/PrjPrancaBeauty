using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Entitis;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Templates
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.GeneralTemplate).IsRequired();

            builder.HasOne(a => a.Language)
                .WithMany(a => a.Templates)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.LangId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
