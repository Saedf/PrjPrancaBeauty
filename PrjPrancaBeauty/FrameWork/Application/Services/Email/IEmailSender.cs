using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Application.Services.Email
{
    public interface IEmailSender
    {
        public bool Send(string _to, string _subject, string _message);
        public Task SendAsync(string _to, string _subject, string _message);
    }
}
