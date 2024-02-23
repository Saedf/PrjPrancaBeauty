using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.Users.UserAgg.Contracts;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Users
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
