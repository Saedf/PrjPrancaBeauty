using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Apps.Settings;
using PrancaBeauty.Application.Contracts.Settings;
using PrancaBeauty.Domain.Settings.SettingsAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Settings
{
    public class SettingApplication: ISettingApplication
    {
        private readonly ISettingRepository _settingRepository;
        private List<OutSettings> _settingsList;
        private readonly ILogger _logger;

        public SettingApplication(ISettingRepository settingRepository, ILogger logger)
        {
            _settingRepository = settingRepository;
            _settingsList = new List<OutSettings>();
            _logger = logger;
        }

        public async Task<OutSettings> GetSettingAsync(string langCode)
        {
            if (_settingsList != null)
                if (_settingsList.Any(a => a.LangCode == langCode))
                    return _settingsList.Single(a => a.LangCode == langCode);
            var qSetting = await LoadSettingAsync(langCode);
            if (qSetting == null)
                throw new Exception("");

            _settingsList.Add(qSetting);
            return qSetting;
        }
        private async Task<OutSettings> LoadSettingAsync(string langCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(langCode))
                    throw new ArgumentNullException("langCode can't be null");

                var qDate = await _settingRepository.GetNoTraking
                    .Where(a => a.Language.Code == langCode)
                    .Where(z => z.IsEnable == true)
                    .Select(x => new OutSettings
                    {
                        IsInManufacture = x.IsInManufacture,
                        LangCode = x.Language.Code,
                        SiteDescription = x.SiteDescription,
                        SitePhoneNumber = x.SitePhoneNumber,
                        SiteTitle = x.SiteTitle,
                        SiteUrl = x.SiteUrl,
                    })
                    .SingleOrDefaultAsync();

                if (qDate == null)
                    throw new Exception($"qDate is null, LangCode:[{langCode}]");

                return qDate;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
        public void CleareCache()
        {
            _settingsList = new List<OutSettings>();
        }

    }
}
