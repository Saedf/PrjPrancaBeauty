using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Domain.Users.UserAgg.Entities
{
    public class User:IdentityUser<Guid>,IEntity
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid AccessLevelId { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeller { get; set; }
        public virtual AccessLevel AccessLevel { get; set; }


    }
}
