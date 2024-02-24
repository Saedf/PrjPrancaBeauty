using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Templates
{
    public interface ITemplateApplication
    {
        Task<string> GetEmailChangeTemplateAsync(InpGetEmailChangeTemplate Input);
        Task<string> GetEmailConfirmationTemplateAsync(InpGetEmailConfirmationTemplate Input);
        Task<string> GetEmailLoginTemplateAsync(InpGetEmailLoginTemplate Input);
        Task<string> GetEmailRecoveryPasswordTemplateAsync(InpGetEmailRecoveryPasswordTemplate Input);
    }
}
