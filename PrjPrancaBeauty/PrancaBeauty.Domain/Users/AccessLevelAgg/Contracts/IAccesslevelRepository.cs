using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Domain.Users.AccessLevelAgg.Contracts
{
    public interface IAccesslevelRepository: IRepository<AccessLevel>
    {
    }
}
