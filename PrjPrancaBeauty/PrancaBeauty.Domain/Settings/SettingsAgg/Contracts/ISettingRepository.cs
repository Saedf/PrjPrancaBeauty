using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Settings.SettingsAgg.Entities;

namespace PrancaBeauty.Domain.Settings.SettingsAgg.Contracts
{
    public interface ISettingRepository: IRepository<Setting>
    {
    }
}
