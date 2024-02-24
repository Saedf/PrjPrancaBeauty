using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Contracts.Users
{
    public class InpGenerateEmailConfirmationToken
    {
        [Display(Name = "UserId")]
       
        public string UserId { get; set; }
    }
}
