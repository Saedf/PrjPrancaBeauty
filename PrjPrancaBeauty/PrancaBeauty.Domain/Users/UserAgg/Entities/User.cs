using FrameWork.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;

namespace PrancaBeauty.Domain.Users.UserAgg.Entities
{
    public class User:IdentityUser<Guid>,IEntity
    {

        public Guid? LangId { get; set; }
        public Guid? ProfileImgId { get; set; }
        public Guid AccessLevelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime Date { get; set; }
        public string PasswordPhoneNumber { get; set; }
        public DateTime? LastTrySentSms { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeller { get; set; }
        public virtual AccessLevel AccessLevel { get; set; }


    }
}
