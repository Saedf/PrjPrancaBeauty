using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viRegisterModel
    {
        [Display(Name = "Email")]
        [Required ]
        [StringLength(100,MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "FirstName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"[A-Zآا-ی a-z \s]*")]

        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"[A-Zآا-ی a-z \s]*")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "PassCompareMsg")]
        public string ConfirmPassword { get; set; }
    }
}
