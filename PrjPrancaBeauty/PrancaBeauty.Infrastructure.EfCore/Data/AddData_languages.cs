using FrameWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
   
    public class AddData_languages
    {
        BaseRepository<Language> _repLang;

        public AddData_languages()
        {
            _repLang = new BaseRepository<Language>(new MainContext());
        }


        public void Run()
        {
            if (!_repLang.GetNoTraking.Any(a => a.Code == "fa-IR"))
            {
                _repLang.AddAsync(new Language()
                {
                    Id = new Guid().SequentialGuid(),
                    Code = "fa-IR",
                    IsActive = true,
                    IsRtl = true,
                    Name = "Persian_IR",
                    NativeName = "فارسی (ایران)",
                    Abbr = "fa",
                    UseForSiteLanguage = true,
                    //  CountryId = _Country.Get.Where(a => a.Name == "Iran").Select(a => a.Id).Single()
                }, default, true).Wait();
            }

            if (!_repLang.GetNoTraking.Any(a => a.Code == "en-US"))
            {
                _repLang.AddAsync(new Language()
                {
                    Id = new Guid().SequentialGuid(),
                    Code = "en-US",
                    IsActive = true,
                    IsRtl = false,
                    Name = "English_USA",
                    NativeName = "English (USA)",
                    Abbr = "en",
                    UseForSiteLanguage = true,
                    // CountryId = _Country.Get.Where(a => a.Name == "USA").Select(a => a.Id).Single()
                }, default, true).Wait();
            }
        }
    }
}
