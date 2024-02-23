using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace PrancaBeauty.Domain.Users.RoleAgg.Entities
{
    public class Role:IdentityRole<Guid>,IEntity
    {
        public string Description { get; set; }
        public int Sort { get; set; }
        public string PageName { get; set; }
        public Guid? ParentId { get; set; }//as a subscriber


    }
}
