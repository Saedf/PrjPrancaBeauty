using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;

namespace PrancaBeauty.Domain.Users.RoleAgg.Contracts
{
    public interface IRoleRepository:IRepository<Role>

    {
    }
}
