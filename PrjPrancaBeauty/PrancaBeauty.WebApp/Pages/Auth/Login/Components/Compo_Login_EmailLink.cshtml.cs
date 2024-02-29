using FrameWork.Application.Consts;
using FrameWork.Application.Services.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Settings;
using PrancaBeauty.Application.Apps.Templates;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utility.MsgBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Net;
using FrameWork.Common.ExMethods;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class Compo_Login_EmailLinkModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
        private readonly IEmailSender _EmailSender;
        private readonly IUserApplication _UserApplication;
        private readonly ILocalizer _Localizer;
        private readonly ISettingApplication _SettingApplication;
        private readonly ITemplateApplication _TemplateApplication;

        public Compo_Login_EmailLinkModel(IMsgBox msgBox, IEmailSender emailSender, IUserApplication userApplication, ILocalizer localizer, ISettingApplication settingApplication, ITemplateApplication templateApplication)
        {
            _MsgBox = msgBox;
            _EmailSender = emailSender;
            _UserApplication = userApplication;
            _Localizer = localizer;
            _SettingApplication = settingApplication;
            _TemplateApplication = templateApplication;
        }


        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "/Auth/User/Index";
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _MsgBox.ModelStateMsg(ModelState.GetErrors());

            Thread.Sleep(3000);

            var Result = await _UserApplication.LoginByEmailLinkStep1Async(Input.Email, HttpContext.Connection.RemoteIpAddress.ToString());
            if (Result.IsSucceeded)
            {
                string Token = (Result.Message + ", " + Input.RemmeberMe).AesEncrypt(AuthConst.SecretKey);
                string _Url = (await _SettingApplication.GetSettingAsync( CultureInfo.CurrentCulture.Name )).SiteUrl + $"/{CultureInfo.CurrentCulture.Parent.Name}/EmailLogin?Token={WebUtility.UrlEncode(Token)}";

                await _EmailSender.SendAsync(Input.Email, _Localizer["EmailLoginSubject"], await _TemplateApplication.GetEmailLoginTemplateAsync( CultureInfo.CurrentCulture.Name,  _Url));

                return _MsgBox.SuccessMsg(_Localizer["EmailLoginSent"], "location.href='/';");
            }
            else
            {
                return _MsgBox.FailedMsg(_Localizer[Result.Message]);
            }
            return Page();
        }
        [BindProperty]
        public viCompo_Login_EmailLinkModel Input { get; set; }
        
    }
}
