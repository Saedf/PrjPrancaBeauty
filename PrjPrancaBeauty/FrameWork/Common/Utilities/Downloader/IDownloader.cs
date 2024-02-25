using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Common.Utilities.Downloader
{
    public interface IDownloader
    {
        Task<string?> GetHtmlFromPageAsync(string PageUrl, object? Data, Dictionary<string, string> Headers);
    }
}
