using FrameWork.Infrastructure;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data;

public class AddData_Settings
{
    //private BaseRepository<TblSettings> _repSetting = new(new MainContext());
    //private BaseRepository<TblLanguages> _repLang = new(new MainContext());
    public void Run()
    {
        //if (!_repSetting.Get.Any(a => a.IsEnable == true && a.Languages.Code == "fa-IR"))
        //{
        //    _repSetting.AddAsync(new TblSettings
        //    {
        //        Id = new Guid(),
        //        CreationDate = DateTime.Now,
        //        IsEnable = true,
        //        IsInManufacture = false,
        //        LangId = _repLang.Get.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
        //        SiteDescription = "سایت فروشگاهی اینترنتی",
        //        SitePhoneNumber = "0912586933",
        //        SiteTitle = "PrancaBeauty",
        //        SiteUrl = "https://localhost:7084",
        //        Sitemail = ""
        //    }, default, true).Wait();
        //}
    }
}