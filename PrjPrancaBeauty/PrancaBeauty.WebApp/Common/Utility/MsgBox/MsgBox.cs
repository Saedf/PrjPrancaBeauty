﻿using PrancaBeauty.WebApp.Common.Types;
using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Common.Utility.MsgBox
{
    public class MsgBox:IMsgBox
    {
        private readonly ILocalizer _Localizer;

        public MsgBox(ILocalizer localizer)
        {
            _Localizer = localizer;
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


        public JsResult AccessDeniedMsg(string CallBackFuncs = "function(){locaton.reload();}")
        {
            return new JsResult(Show("", _Localizer["AccessDeniedMsg"], MsgBoxType.error, _Localizer["OK"], CallBackFuncs));
        }

        public JsResult ModelStateMsg(string ModelErrors, string CallBackFuncs = null)
        {
            return new JsResult(Show("", ModelErrors.Replace(",", "<br/>"), MsgBoxType.error, _Localizer["OK"], CallBackFuncs));
        }

        public JsResult FailedMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.error, _Localizer["OK"], CallBackFuncs));
        }

        public JsResult InfoMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.info, _Localizer["OK"], CallBackFuncs));
        }

        public JsResult SuccessMsg(string Message, string CallBackFuncs = null)
        {
            return new JsResult(Show("", Message, MsgBoxType.success, _Localizer["OK"], CallBackFuncs));
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
