using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Domain.Users.AccessLevelAgg.Entities
{
    public class AccessLevel:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<AccessLevel_Roles> AccessLevelRoles { get; set; }

    } 
}
