using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;

namespace PrancaBeauty.Domain.Users.AccessLevelAgg.Entities
{
    public class AccessLevel_Roles: IEntity
    {
        public Guid Id { get; set; }
        public Guid AccessLevelId { get; set; }
        public Guid RoleId { get; set; }

        public virtual AccessLevel AccessLevels { get; set; }
        public virtual Role Roles { get; set; }

    }
}
