using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viCompo_Login_EmailLinkModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredStringMsg")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "RemmeberMe")]
        public bool RemmeberMe { get; set; }
    }
}
