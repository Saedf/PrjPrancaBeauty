using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain;
using Microsoft.AspNetCore.Identity;

namespace PrancaBeauty.Domain.Users.UserAgg.Entities
{
    public class TblUser:IdentityUser<Guid>,IEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }

    }
}
