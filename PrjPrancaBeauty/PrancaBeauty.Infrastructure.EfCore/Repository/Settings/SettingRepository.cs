using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Settings.SettingsAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Settings.SettingsAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Settings
{
    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(MainContext context) : base(context)
        {
        }
    }
}
