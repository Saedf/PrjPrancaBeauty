using FrameWork.Application.Consts;
using FrameWork.Common.ExMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Net;
using FrameWork.Application.Services.Email;
using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserApplication _userApplication;
        private readonly IEmailSender _emailSender;
        private readonly ILocalizer _localizer;

        public RegisterModel(IUserApplication userApplication, IEmailSender emailSender, ILocalizer localizer)
        {
            _userApplication = userApplication;
            _emailSender = emailSender;
            _localizer = localizer;
        }

        public IActionResult OnGet()
        {
             return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var result = await _userApplication.AddUserAsync(new InpAddUser
            {
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Password = Input.Password
            });
            if (result.IsSucceeded)
            {
                if (result.Code == 1)
                {
                    #region ارسال ایمیل تایید

                    {
                        string UserId = result.Message;
                        string Token = await _userApplication.GenerateEmailConfirmationTokenAsync(new InpGenerateEmailConfirmationToken { UserId = UserId });
                        string EncToken = $"{UserId}, {Token}".AesEncrypt(AuthConst.SecretKey);

                     //   string SiteUrl = (await _SettingApplication.GetSettingAsync(new InpGetSetting { LangCode = CultureInfo.CurrentCulture.Name })).SiteUrl;

                       string url = $"/Auth/EmailConfirmation?Token={WebUtility.UrlEncode(EncToken)}";
                    //   await _emailSender.SendAsync(Input.Email, _localizer["RegistrationEmailSubject"], await _TemplateApplication.GetEmailConfirmationTemplateAsync(new InpGetEmailConfirmationTemplate { LangCode = CultureInfo.CurrentCulture.Name, Url = url }));
                    }
                    #endregion

                   // return Redirect($"/{CultureInfo.CurrentCulture.Parent.Name}/Auth/AccountCreate");
                }
                else
                    return Redirect($"/Auth/AccountCreate");

                return Page();
            }
            else
            {
                foreach (var item in result.Message.Split(", "))
                {
                    ModelState.AddModelError("", item);
                }

                return Page();
            }
          
        }

        [BindProperty]
        public viRegisterModel Input { get; set; }
    }
}
