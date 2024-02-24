using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PrancaBeauty.WebApp.Common.ExMethod
{
    public static class ModelStateEx
    {
        public static string GetErrors(this ModelStateDictionary modelstate, string seprator = "<br/>")
        {
            var messages = string.Join(seprator, modelstate.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            return messages;
        }
    }
}
