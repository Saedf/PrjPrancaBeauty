using FrameWork.Infrastructure;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data;

public class AddData_Users
{
    BaseRepository<User> _usersRepository;
    BaseRepository<AccessLevel> _repAccessLevel;
    BaseRepository<Role> _repRoles;
    MainContext _mainContext;

    public AddData_Users()
    {
        _usersRepository = new BaseRepository<User>(new MainContext());
        _repAccessLevel = new BaseRepository<AccessLevel>(new MainContext());
        _repRoles = new BaseRepository<Role>(new MainContext());
        _mainContext = new MainContext();
    }

    public void Run()
    {
        if (!_usersRepository.Get.Any(a => a.UserName == "saed.fathi135"))
        {
            Guid UserId = new Guid().SequentialGuid();
            _usersRepository.AddAsync(new User()
            {
                Id = UserId,
                AccessLevelId = _repAccessLevel.Get.Where(a => a.Name == "GeneralManager").Select(a => a.Id).Single(),
                FirstName = "ساعد",
                LastName = "فتحی",
                IsActive = true,
                Date = DateTime.Now,
                UserName = "saed.fathi135",
                NormalizedUserName = "saed.fathi135".ToUpper(),
                Email = "saed.fathi135@gmail.com",
                NormalizedEmail = "saed.fathi135@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEO3Ro+1N3qaDwJUK02Qih+FlDMKZxhO0Z2JPMgd3rgrQSPeFLQh3txpgkEvlFMRUXA==", // 123456
                SecurityStamp = "QHZXXDN4PZUNNXGC6LQRVNOZ5EGGIKWH",
                ConcurrencyStamp = "37116a3b-0da5-460e-b266-d5243f62e5c8",
                PhoneNumber = "09384649127",
                PhoneNumberConfirmed = true,
                 IsSeller = false
            }, default, true).Wait();
            foreach (var item in _repRoles.Get.ToList())
            {
                _mainContext.Add(new IdentityUserRole<Guid>
                {
                    UserId = UserId,
                    RoleId = item.Id
                });
            }

            _mainContext.SaveChanges();

        }
    }

}