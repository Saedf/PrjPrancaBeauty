using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;

namespace PrancaBeauty.Infrastructure.EfCore.Seed
{
    public class SeedRoles
    {
        public void Run(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role()
            {
                Id = new Guid().SequentialGuid(),
                ParentId = null,
                PageName = "FullControl",
                Sort = 0,
                Name = "FullControl",
                NormalizedName = "FullControl".ToUpper(),
                Description = "دسترسی مدیر کل"
            });
        }
    }
}
