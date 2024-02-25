using FrameWork.Application.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using System.Threading.Tasks;
using FrameWork.Common.ExMethods;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class EmailConfirmationModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        public EmailConfirmationModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return Page();

                string decreptedToken = token.AesDecrypt(AuthConst.SecretKey);

                string strUserId = decreptedToken.Split(", ")[0];
                string strToken = decreptedToken.Split(", ")[1];


                var Result = await _userApplication.EmailConfirmationAsync(strUserId,strToken);
                if (Result.IsSucceeded)
                {
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception)
            {
                return Page();
            }

        }
    }
}
