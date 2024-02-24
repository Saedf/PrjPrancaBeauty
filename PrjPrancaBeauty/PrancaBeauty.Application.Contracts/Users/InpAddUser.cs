using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Contracts.Users
{
    public class InpAddUser
    {
        [Display(Name = "Email")]
       
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
    }
}
