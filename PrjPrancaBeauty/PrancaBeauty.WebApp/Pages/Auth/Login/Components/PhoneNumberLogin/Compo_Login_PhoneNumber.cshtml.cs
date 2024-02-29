using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utility.MsgBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components.PhoneNumberLogin
{
    public class Compo_Login_PhoneNumberModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
       // private readonly ISmsSender _SmsSender;
        private readonly ILocalizer _Localizer;
        private readonly IUserApplication _UserApplication;

        public Compo_Login_PhoneNumberModel(IMsgBox msgBox, ILocalizer localizer, IUserApplication userApplication)
        {
            _MsgBox = msgBox;
            _Localizer = localizer;
            _UserApplication = userApplication;     
        }

        public PageResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _MsgBox.ModelStateMsg(ModelState.GetErrors());

            //var Result = await _UserApplication.LoginByPhoneNumberStep1Async(new InpLoginByPhoneNumberStep1 { PhoneNumber = Input.PhoneNumber });
            //if (Result.IsSucceeded)
            //{
            //    var IsSend = _SmsSender.SendLoginCode(Input.PhoneNumber, Result.Message);
            //    if (IsSend)
            //        return _MsgBox.SuccessMsg(_Localizer["LoginCodeIsSent"], "GotoOtpPage()");
            //    else
            //        return _MsgBox.FailedMsg(_Localizer["SmsSenderNotRespond"]);
            //}
            //else
            //{
            //    return _MsgBox.FailedMsg(_Localizer[Result.Message]);
            //}
            return Page();
        }
        [BindProperty]
        public viCompo_Login_PhoneNumberModel Input { get; set; }
    }
}
