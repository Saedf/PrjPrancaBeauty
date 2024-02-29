using PrancaBeauty.Domain.Templates.TemplatesAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Templates;
using PrancaBeauty.Application.Apps.Settings;

namespace PrancaBeauty.Application.Apps.Templates
{
    public class TemplateApplication:ITemplateApplication
    {
        private readonly ILogger _logger;
       
        private readonly ITemplateRepository _templateRepository;
        private readonly ISettingApplication _settingApplication;
        private List<OutTemplates> _listTemplates;
        public TemplateApplication(ITemplateRepository templateRepository, ILogger logger, ISettingApplication settingApplication)
        {
            _templateRepository = templateRepository;
            _logger = logger;
            _settingApplication = settingApplication;
            _listTemplates = new List<OutTemplates>();
        }

      
       

        public async Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url)
        {
            var template = await GetTemplateAsync(langCode, "ConfirmationEmail");
            return (await SetGeneralParameters(template, langCode)).Replace("[Url]", url);
        }

       
        public async Task<string> GetTemplateAsync(string langCode, string name)
        {
            if (_listTemplates != null)
                if (_listTemplates.Any(a => a.Name == name && a.LangCode == langCode))
                    return _listTemplates.Where(a => a.Name == name && a.LangCode == langCode).Select(a => a.Template).Single();

            string _template = await _templateRepository.GetNoTraking
                .Where(a => a.Name == name && a.Language.Code == langCode)
                .Select(a => a.GeneralTemplate)
                .SingleAsync();

            _listTemplates.Add(new OutTemplates
            {
                Name = name,
                LangCode = langCode,
                Template = _template
            }); ;

            return _template;
        }

        public async Task<string> GetEmailLoginTemplateAsync(string langCode, string url)
        {
            try
            {
                #region Validations
               // Input.CheckModelState(_ServiceProvider);
                #endregion

                string _Template = await GetTemplateAsync(langCode, "EmailLogin");

                return (await SetGeneralParameters(_Template, langCode))
                    .Replace("[Url]", url);
            }
            //catch (ArgumentInvalidException ex)
            //{
            //    _Logger.Debug(ex);
            //    return null;
            //}
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        private async Task<string> SetGeneralParameters(string template, string langCode)
        {
            var qSetting = await _settingApplication.GetSettingAsync(langCode);

            return template.Replace("[SiteName]", qSetting.SiteTitle)
                .Replace("[SiteUrl]", qSetting.SiteUrl);
        }

        public void ClearCache()
        {
            _listTemplates = new List<OutTemplates>();
        }
    }
}
