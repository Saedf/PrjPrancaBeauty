using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Templates
{
    public interface ITemplateApplication
    {
        Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url);
        Task<string> GetTemplateAsync(string langCode, string name);
        Task<string> GetEmailLoginTemplateAsync(string langCode, string url);
    }
}
