using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }
        public void OnPost()
        {

        }
        public viRegisterModel Input { get; set; }
    }
}
