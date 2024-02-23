using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viRegisterModel
    {
        [Display(Name = "Email")]
      
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
       public string PhoneNumber { get; set; }

        [Display(Name = "FirstName")]
      

        public string FirstName { get; set; }

        [Display(Name = "LastName")]
       
        public string LastName { get; set; }

        [Display(Name = "Password")]
      
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
      
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "PassCompareMsg")]
        public string ConfirmPassword { get; set; }
    }
}
