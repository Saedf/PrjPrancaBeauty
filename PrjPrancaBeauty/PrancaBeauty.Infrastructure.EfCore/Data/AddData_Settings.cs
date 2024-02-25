using FrameWork.Infrastructure;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;
using PrancaBeauty.Domain.Settings.SettingsAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data;

public class AddData_Settings
{
    private BaseRepository<Setting> _repSetting = new(new MainContext());
    private BaseRepository<Language> _repLang = new(new MainContext());
    public void Run()
    {
        if (!_repSetting.Get.Any(a => a.IsEnable == true && a.Language.Code == "fa-IR"))
        {
            _repSetting.AddAsync(new Setting
            {
                Id = new Guid(),
                CreationDate = DateTime.Now,
                IsEnable = true,
                IsInManufacture = false,
                LangId = _repLang.Get.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                SiteDescription = "سایت فروشگاهی اینترنتی",
                SitePhoneNumber = "0912586933",
                SiteTitle = "PrancaBeauty",
                SiteUrl = "https://localhost:7068",
                Sitemail = "info@prancabeauty.com"
            }, default, true).Wait();
        }
        if (!_repSetting.Get.Any(a => a.IsEnable == true && a.Language.Code == "en-US"))
        {
            _repSetting.AddAsync(new Setting()
            {
                Id = new Guid().SequentialGuid(),
                CreationDate = DateTime.Now,
                IsEnable = true,
                IsInManufacture = false,
                LangId = _repLang.Get.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                SiteDescription = "PrancaBeauty Shop",
                Sitemail = "info@prancabeauty.com",
                SitePhoneNumber = "09147922542",
                SiteTitle = "PrancaBeauty",
                SiteUrl = "https://localhost:7068"
            }, default, true).Wait();
        }
    }
}