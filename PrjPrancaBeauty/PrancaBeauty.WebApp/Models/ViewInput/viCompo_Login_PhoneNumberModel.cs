using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viCompo_Login_PhoneNumberModel
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "RequiredStringMsg")]
        [Phone(ErrorMessage = "MobilePattern")]
        public string PhoneNumber { get; set; }
    }
}
