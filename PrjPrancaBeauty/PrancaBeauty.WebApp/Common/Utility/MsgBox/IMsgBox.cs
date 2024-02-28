using PrancaBeauty.WebApp.Common.Types;

namespace PrancaBeauty.WebApp.Common.Utility.MsgBox
{
    public interface IMsgBox
    {
        JsResult AccessDeniedMsg(string CallBackFuncs = "function(){locaton.reload();}");
        JsResult FailedMsg(string Message, string CallBackFuncs = null);
        JsResult InfoMsg(string Message, string CallBackFuncs = null);
        JsResult ModelStateMsg(string ModelErrors, string CallBackFuncs = null);
        JsResult SuccessMsg(string Message, string CallBackFuncs = null);
    }
}
