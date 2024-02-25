using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viCompo_Login_UserNamePasswordModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredStringMsg")]
       
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "RequiredStringMsg")]
        public string Password { get; set; }

        [Display(Name = "RemmeberMe")]
        public bool RemmeberMe { get; set; }

    }
}
