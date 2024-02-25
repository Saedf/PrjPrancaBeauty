using PrancaBeauty.Application.Contracts.Settings;

namespace PrancaBeauty.Application.Apps.Settings
{
    public interface ISettingApplication
    {
        Task<OutSettings> GetSettingAsync(string langCode);
    }
}
