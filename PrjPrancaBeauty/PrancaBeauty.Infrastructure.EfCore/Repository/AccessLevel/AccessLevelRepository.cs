using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel
{
    public class AccessLevelRepository : BaseRepository<Domain.Users.AccessLevelAgg.Entities.AccessLevel>, IAccesslevelRepository
    {

        public AccessLevelRepository(MainContext Context) : base(Context)
        {

        }
    }
}
