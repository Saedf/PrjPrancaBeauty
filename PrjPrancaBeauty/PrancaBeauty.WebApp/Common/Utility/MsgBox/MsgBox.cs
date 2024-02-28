using PrancaBeauty.WebApp.Common.Types;
using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Common.Utility.MsgBox
{
    public class MsgBox:IMsgBox
    {
        private readonly ILocalizer _localizer;

        public MsgBox(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        private string Show(string Title, string Message, MsgBoxType Type, string OkBtnText = "OK", string CallBackFunction = null)
        {

            CallBackFunction = CallBackFunction ?? "return '';";
            string Js = $@"swal.fire({{
                                        title: '{Title.Replace("'", "`")}',
                                        html: '{Message.Replace("'", "`")}',
                                        icon: '{Type.ToString()}',
                                        confirmButtonText: '{OkBtnText}',
                                    }}).then((result) => {{
                                        if (result.isConfirmed) {{
                                          {CallBackFunction};
                                        }}
                                    }});";

            return Js;
        }

        public JsResult ModelStateMsg(string ModelErrors, string CallBackFuncs = null)
        {
            return new JsResult(Show("", ModelErrors.Replace(",", "<br/>"), MsgBoxType.error, _localizer["OK"], CallBackFuncs));
        }

        public JsResult FaildMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.error, _localizer["OK"], CallBackFuncs));
        }

        public JsResult InfoMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.info, _localizer["OK"], CallBackFuncs));
        }

        public JsResult SuccessMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.success, _localizer["OK"], CallBackFuncs));
        }

        public JsResult AccessDeniedMsg(string CallBackFuncs = "function(){locaton.reload();}")
        {
            return new JsResult(Show("", _localizer["AccessDeniedMsg"], MsgBoxType.error, _localizer["OK"], CallBackFuncs));
        }
    }

    public enum MsgBoxType
    {
        success,
        error,
        warning,
        info,
        //question
    }
}

