using PrancaBeauty.Domain.Templates.TemplatesAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Templates;


namespace PrancaBeauty.Application.Apps.Templates
{
    public class TemplateApplication:ITemplateApplication
    {
        private readonly ILogger _logger;
        //private readonly ILocalizer _localizer;
        //private readonly IServiceProvider _serviceProvider;
        private readonly ITemplateRepository _templateRepository;
        private List<OutTemplates> _listTemplates;
        public TemplateApplication(ITemplateRepository templateRepository, ILogger logger, List<OutTemplates> listTemplates)
        {
            _templateRepository = templateRepository;
            _logger = logger;
            _listTemplates = listTemplates;
        }

        public Task<string> GetEmailChangeTemplateAsync(InpGetEmailChangeTemplate Input)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url)
        {
            //try
            //{
            //    #region Validations
            //    Input.CheckModelState(_ServiceProvider);
            //    #endregion

            //    string _Template = await GetTemplateAsync(Input.LangCode, "ConfirmationEmail");

            //    return (await SetGeneralParameters(_Template, Input.LangCode))
            //        .Replace("[Url]", Input.Url);
            //}
            //catch (ArgumentInvalidException ex)
            //{
            //    _logger.Debug(ex);
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error(ex);
            //    return null;
            //}
            string template = await GetTemplateAsync(langCode, "");
            return SetGeneralParameters(template,langCode);
        }

        public Task<string> GetEmailLoginTemplateAsync(InpGetEmailLoginTemplate Input)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailRecoveryPasswordTemplateAsync(InpGetEmailRecoveryPasswordTemplate Input)
        {
            throw new NotImplementedException();
        }
        private async Task<string> GetTemplateAsync(string langCode, string name)
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

        private async Task<string> SetGeneralParameters(string template, string langCode)
        {
            //var qSetting = await _SettingApplication.GetSettingAsync(new InpGetSetting { LangCode = langCode });

            //return template.Replace("[SiteName]", qSetting.SiteTitle)
            //    .Replace("[SiteUrl]", qSetting.SiteUrl);
            return template;
        }

        public void ClearCache()
        {
            _listTemplates = new List<OutTemplates>();
        }
    }
}
