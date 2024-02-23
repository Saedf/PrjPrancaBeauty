using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Users.AccessLevelAgg.Entities;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data;

public class AddData_AccessLevel
{

    private BaseRepository<AccessLevel> _repAccessLevel = new(new MainContext());
    private BaseRepository<Role> _repRoles = new(new MainContext());

    public void Run()
    {
        if (!_repAccessLevel.Get.Any(a => a.Name == "GeneralManager"))
        {
            var qAccRole = new AccessLevel()
            {
                Id = new Guid().SequentialGuid(),
                Name = "GeneralManager",
                AccessLevelRoles = new List<AccessLevel_Roles>()
            };
            foreach (var item in _repRoles.Get.ToList())
            {
                qAccRole.AccessLevelRoles.Add(new AccessLevel_Roles
                {
                    Id = new Guid().SequentialGuid(),
                    AccessLevelId = qAccRole.Id,
                    RoleId = item.Id,
                });
            }
            _repAccessLevel.AddAsync(qAccRole, default, false).Wait();
        }

        if (!_repAccessLevel.Get.Any(a => a.Name == "Users"))
        {
            _repAccessLevel.AddAsync(new AccessLevel()
            {
                Id = new Guid().SequentialGuid(),
                Name = "Users"
            }, default, false).Wait();
        }
        _repAccessLevel.SaveChangeAsync().Wait();
    }
}