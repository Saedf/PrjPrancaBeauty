using Microsoft.Extensions.Localization;
using System.Reflection;

namespace PrancaBeauty.WebApp.Localization
{
    public class FactoryLocalizer
    {
        public IStringLocalizer Set(IStringLocalizerFactory factory, Type typeOfSharedResource)
        {
            var assemblyName = new AssemblyName(typeOfSharedResource.GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        }
        public IStringLocalizer Set(IServiceCollection services, Type TypeOfSharedResource)
        {
            var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var assemblyName = new AssemblyName(TypeOfSharedResource.GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        }
    }
}
