using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.RoleAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Roles
{
    public class RoleRepository: BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MainContext  mainContext) : base(mainContext)
        {
        }
    }
}
