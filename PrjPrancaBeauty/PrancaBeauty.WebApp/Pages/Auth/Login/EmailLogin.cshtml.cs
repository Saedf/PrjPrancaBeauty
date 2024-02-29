using FrameWork.Application.Consts;
using FrameWork.Common.ExMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Pages.Auth.Login
{
    public class EmailLoginModel : PageModel
    {
        private readonly ILocalizer _localizer;
        private readonly IJWTBuilder _jwtBuilder;
        private readonly IUserApplication _userApplication;

        public EmailLoginModel(ILocalizer localizer, IJWTBuilder jwtBuilder, IUserApplication userApplication)
        {
            _localizer = localizer;
            _jwtBuilder = jwtBuilder;
            _userApplication = userApplication;
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return StatusCode(400);

            string DecryptedToken = token.AesDecrypt(AuthConst.SecretKey);
            string UserId = DecryptedToken.Split(", ")[0];
            string Password = DecryptedToken.Split(", ")[1];
            string Ip = DecryptedToken.Split(", ")[2];
            string Date = DecryptedToken.Split(", ")[3];
            bool RemmeberMe = bool.Parse(DecryptedToken.Split(", ")[4]);

            var Result = await _userApplication.LoginByEmailLinkStep2Async( UserId,  Password, Ip, HttpContext.Connection.RemoteIpAddress.ToString(), DateTime.Parse(Date));
            if (Result.IsSucceeded)
            {
                string GeneratedToken = await _jwtBuilder.CreateTokenAync(Result.Message);
                Response.CreateAuthCookie(GeneratedToken, RemmeberMe);

                ViewData["Message"] = _localizer["LoginEmailSuccess"];
                ViewData["MsgType"] = "success";
                return Page();
            }
            else
            {
                ViewData["Message"] = _localizer[Result.Message];
                ViewData["MsgType"] = "danger";
                return Page();
            }
        }


    }
}
