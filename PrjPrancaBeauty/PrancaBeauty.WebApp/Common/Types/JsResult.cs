using Microsoft.AspNetCore.Mvc;

namespace PrancaBeauty.WebApp.Common.Types
{
    public class JsResult : ContentResult
    {
        public JsResult(string script)
        {
            Content = script;
            ContentType = "application/javascript";
        }
    }
   
}
