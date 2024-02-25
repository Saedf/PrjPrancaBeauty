using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts
{
    public interface IAccesslevelRolesRepository:IRepository<AccessLevel_Roles>
    {
    }
}
