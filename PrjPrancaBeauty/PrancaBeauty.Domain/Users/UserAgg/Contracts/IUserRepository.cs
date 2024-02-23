using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;

namespace PrancaBeauty.Domain.Users.UserAgg.Contracts
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
