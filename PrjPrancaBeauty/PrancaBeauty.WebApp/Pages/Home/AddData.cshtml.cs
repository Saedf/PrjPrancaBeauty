using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Infrastructure.EfCore.Data;

namespace PrancaBeauty.WebApp.Pages.Home
{
    public class AddDataModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                new AddData_Main().Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
