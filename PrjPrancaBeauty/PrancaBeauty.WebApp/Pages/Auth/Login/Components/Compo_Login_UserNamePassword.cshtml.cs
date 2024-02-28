using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Types;
using PrancaBeauty.WebApp.Common.Utility.MsgBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class Compo_Login_UserNamePasswordModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
        private readonly IUserApplication _UserApplication;
    //    private readonly IJWTBuilder _JWTBuilder;
        private readonly ILocalizer _Localizer;
        public Compo_Login_UserNamePasswordModel(IMsgBox msgBox, ILocalizer localizer)
        {
            _MsgBox = msgBox;
            _Localizer = localizer;
        }
        public IActionResult OnGet(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _MsgBox.ModelStateMsg(ModelState.GetErrors());

            var Result = await _UserApplication.LoginByUserNamePasswordAsync( Input.Email, Input.Password );

            if (Result.IsSucceeded)
            {
                string GeneratedToken = await _JWTBuilder.CreateTokenAync(Result.Message);

                Response.CreateAuthCookie(GeneratedToken, Input.RemmeberMe);

                return new JsResult("GotoReturnUrl()");
            }
            else
            {
                return _MsgBox.InfoMsg(_Localizer[Result.Message]);
            }
        }
        [BindProperty]
        public viCompo_Login_UserNamePasswordModel Input { get; set; }
    }
}
