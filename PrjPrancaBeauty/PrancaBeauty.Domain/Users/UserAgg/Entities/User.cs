using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace PrancaBeauty.Domain.Users.UserAgg.Entities
{
    public class User:IdentityUser<Guid>,IEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }

    }
}
