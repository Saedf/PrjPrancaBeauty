using FrameWork.Common.Utilities.Downloader;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PrancaBeauty.Application.Apps.Settings;
using System.Globalization;
using System.Security.Claims;
using System.Security.Policy;

namespace PrancaBeauty.WebApp.TagHelpers
{
    [HtmlTargetElement("LoadComponent")]
    public class LoadComponentTagHelper: TagHelper
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public HttpContext Context { get; set; }

        private readonly IDownloader _downloader;
        private readonly ISettingApplication _settingApplication;

        public LoadComponentTagHelper(IDownloader downloader, ISettingApplication settingApplication)
        {
            _downloader = downloader;
            _settingApplication = settingApplication;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Url))
                    throw new ArgumentNullException("Url cant be null.");

                if (Context == null)
                    throw new ArgumentNullException("Context cant be null.");

                Url = (await _settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name )).SiteUrl + Url;

                string htmlData = await _downloader.GetHtmlFromPageAsync(Url, Data, Context.Request.Headers
                    .Select(a => new KeyValuePair<string, string>(a.Key, a.Value))
                    .ToDictionary(k => k.Key, v => v.Value));

                if (htmlData == null)
                    throw new Exception("");

                output.TagName = "div";
                if (Id != null)
                    output.Attributes.SetAttribute("id", Id);

                if (Class != null)
                    output.Attributes.SetAttribute("class", Class);

                output.Content.SetHtmlContent(htmlData);
            }
            catch (Exception)
            {
                output.TagName = "div";

                if (Id != null)
                    output.Attributes.SetAttribute("id", Id);

                if (Class != null)
                    output.Attributes.SetAttribute("class", Class);

                output.Content.SetHtmlContent("<err500>Module Error: 500, Internal Server Error</err500>");
            }
            
        }
    }
}
