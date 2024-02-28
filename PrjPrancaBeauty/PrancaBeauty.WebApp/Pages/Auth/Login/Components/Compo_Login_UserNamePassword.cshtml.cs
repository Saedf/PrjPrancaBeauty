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
      private readonly IMsgBox _msgBox;
        private readonly IUserApplication _userApplication;
      //  private readonly IJWTBuilder _JWTBuilder;
        private readonly ILocalizer _localizer;
        public Compo_Login_UserNamePasswordModel(IUserApplication userApplication, ILocalizer localizer, IMsgBox msgBox)
        {
            _userApplication = userApplication;
            _localizer = localizer;
            _msgBox = msgBox;
        }
        public IActionResult OnGet(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

          

            var Result = await _userApplication.LoginByUserNamePasswordAsync(Input.Email,Input.Password);

            if (Result.IsSucceeded)
            {
                // string GeneratedToken = await _JWTBuilder.CreateTokenAync(Result.Message);

               // Response.CreateAuthCookie(GeneratedToken, Input.RemmeberMe);

                return new JsResult("GotoReturnUrl()");
            }
            else
            {
                return _msgBox.InfoMsg(_localizer[Result.Message]);
            }
        }
        [BindProperty]
        public viCompo_Login_UserNamePasswordModel Input { get; set; }
    }
}
