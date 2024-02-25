using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel
{
    public class AccesslevelRolesRepository : BaseRepository<AccessLevel_Roles>, IAccesslevelRolesRepository
    {
        public AccesslevelRolesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
