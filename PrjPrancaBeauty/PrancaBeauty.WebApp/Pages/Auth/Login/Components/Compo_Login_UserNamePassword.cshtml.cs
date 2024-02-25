using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class Compo_Login_UserNamePasswordModel : PageModel
    {
        public Compo_Login_UserNamePasswordModel()
        {
            
        }
        public IActionResult OnGet(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return Page();
        }
        [BindProperty]
        public viCompo_Login_UserNamePasswordModel Input { get; set; }
    }
}
