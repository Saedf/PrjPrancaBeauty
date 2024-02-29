using FrameWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrancaBeauty.Domain.Region.LanguagesAgg.Entities;
using PrancaBeauty.Domain.Templates.TemplatesAgg.Entitis;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMethods;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddData_Template
    {
        BaseRepository<Template> _repTemplate;
        BaseRepository<Language> _repLang;
        public AddData_Template()
        {
            _repTemplate = new BaseRepository<Template>(new MainContext());
            _repLang = new BaseRepository<Language>(new MainContext());
        }
        public void Run()
        {

            // ConfirmationEmail  fa-IR
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "ConfirmationEmail"))
            {
                _repTemplate.AddAsync(new Template()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                    Name = "ConfirmationEmail",
                    GeneralTemplate = "<a href='[Url]'>کلیک</a>"
                }, default, true).Wait();
            }

            // ConfirmationEmail  en-US
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "ConfirmationEmail"))
            {
                _repTemplate.AddAsync(new Template()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                    Name = "ConfirmationEmail",
                    GeneralTemplate = "<a href='[Url]'>Click</a>"
                }, default, true).Wait();
            }

            // EmailLogin  fa-IR
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "EmailLogin"))
            {
                _repTemplate.AddAsync(new Template()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                    Name = "EmailLogin",
                    GeneralTemplate = "<a href='[Url]'>ورود به سایت</a>"
                }, default, true).Wait();
            }

            // EmailLogin  en-US
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "EmailLogin"))
            {
                _repTemplate.AddAsync(new Template()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                    Name = "EmailLogin",
                    GeneralTemplate = "<a href='[Url]'>Click To Login</a>"
                }, default, true).Wait();
            }

            //// ChanageEmail  fa-IR
            //if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "ChanageEmail"))
            //{
            //    _repTemplate.AddAsync(new Template()
            //    {
            //        Id = new Guid().SequentialGuid(),
            //        LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
            //        Name = "ChanageEmail",
            //        GeneralTemplate = "<a href='[Url]'>کلیک</a>"
            //    }, default, true).Wait();
            //}

            //// ChanageEmail  en-US
            //if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "ChanageEmail"))
            //{
            //    _repTemplate.AddAsync(new Template()
            //    {
            //        Id = new Guid().SequentialGuid(),
            //        LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
            //        Name = "ChanageEmail",
            //        GeneralTemplate = "<a href='[Url]'>Click</a>"
            //    }, default, true).Wait();
            //}

            //// RecoveryPassword  fa-IR
            //if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "RecoveryPassword"))
            //{
            //    _repTemplate.AddAsync(new Template()
            //    {
            //        Id = new Guid().SequentialGuid(),
            //        LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
            //        Name = "RecoveryPassword",
            //        GeneralTemplate = "<a href='[Url]'>کلیک</a>"
            //    }, default, true).Wait();
            //}

            //// RecoveryPassword  en-US
            //if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "RecoveryPassword"))
            //{
            //    _repTemplate.AddAsync(new Template()
            //    {
            //        Id = new Guid().SequentialGuid(),
            //        LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
            //        Name = "RecoveryPassword",
            //        GeneralTemplate = "<a href='[Url]'>Click</a>"
            //    }, default, true).Wait();
            //}
        }

    }
}
