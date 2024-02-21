using FrameWork.Common.ExMethods;

namespace PrancaBeauty.WebApp.Authentication
{
    public class JwtAuthenticationWebAppMiddleware
    {
        private readonly string _SecretKey;
        private readonly string _CookieName;

        private readonly RequestDelegate _Next;
        public JwtAuthenticationWebAppMiddleware(RequestDelegate Next, string SecretKey, string CookieName)
        {
            _SecretKey = SecretKey;
            _CookieName = CookieName;

            _Next = Next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // کوکی های شماره گذاری شده که زمان لاگین ایجاد کرده بودیم را به هم الحاق میکنیم و سپس رمز گشایی و در هدر اصلی میریزیم

            string _EncrptedTokan = null;

            for (int i = 0; i < 10; i++)
                if (context.Request.Cookies[_CookieName + i] != null)
                    _EncrptedTokan += context.Request.Cookies[_CookieName + i].ToString();

            if (_EncrptedTokan != null)
                context.Request.Headers.Add("Authorization", _EncrptedTokan.AesDecrypt(_SecretKey));

            await _Next(context);
        } 
    }
}
