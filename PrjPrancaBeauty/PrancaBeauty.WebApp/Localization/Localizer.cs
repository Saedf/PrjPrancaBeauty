using Microsoft.Extensions.Localization;
using PrancaBeauty.WebApp.Localization.Resource;

namespace PrancaBeauty.WebApp.Localization
{
    public class Localizer:ILocalizer
    {
        public string this[string Name] => Get(Name);

        public string this[string Name, params object[] arguments] => Get(Name, arguments);
        private readonly IStringLocalizer _sharedLocalizer;

        public Localizer(IStringLocalizerFactory stringLocalizerFactory)
        {
            _sharedLocalizer = new FactoryLocalizer().Set(stringLocalizerFactory, typeof(SharedResource));
        }

        public Localizer(IStringLocalizer sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }

        private string Get(string name)
        {
            return _sharedLocalizer[name];

        }

        private string Get(string name, params object[] arguments)
        {
            return _sharedLocalizer[name, arguments];
        }

    }
}
