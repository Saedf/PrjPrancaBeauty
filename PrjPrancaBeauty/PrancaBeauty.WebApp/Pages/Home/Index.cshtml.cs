using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILocalizer _localizer;

        public IndexModel(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public void OnGet()
        {
            string Msg = _localizer["Hello"];
        }
    }
}
