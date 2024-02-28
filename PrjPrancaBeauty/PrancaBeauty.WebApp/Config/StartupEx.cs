using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.WebEncoders;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.WebApp.Localization;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Domain.Users.RoleAgg.Entities;
using PrancaBeauty.Domain.Users.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using PrancaBeauty.WebApp.Common.Utility.MsgBox;

namespace PrancaBeauty.WebApp.Config
{
    public static class StartupEx
    {
        public static IServiceCollection WebEncoderConfig(this IServiceCollection services)
        {
          return services.Configure<WebEncoderOptions>(opt =>
            {
                opt.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.Arabic, UnicodeRanges.BasicLatin);
            });
        }

        public static IMvcBuilder AddRazorPage(this IServiceCollection services)
        {
          return  services.AddRazorPages(a => a.Conventions.AddPageRoute("/Home/Index", ""));
        }
        public static IServiceCollection AddLocalization(this IServiceCollection services,string resourcePath)
        {
            return services.AddLocalization(a=>a.ResourcesPath=resourcePath);
        }
        public static IApplicationBuilder UseLocalization(this IApplicationBuilder app, List<CultureInfo> supportedLans, string defaultCultureName = "fa-IR")
        {
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(defaultCultureName),
                SupportedCultures = supportedLans,
                SupportedUICultures = supportedLans,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new CookieRequestCultureProvider(),
                    new QueryStringRequestCultureProvider()
                }

            };
            return app.UseRequestLocalization(options);

        }
        public static IMvcBuilder AddCustomViewLocalization(this IMvcBuilder builder, string resourcePath)
        {
            builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, option =>
            {
                option.ResourcesPath = resourcePath;
            });
            return builder;
        }
        public static IMvcBuilder AddCustomDataAnotaionLocalization(this IMvcBuilder builder, IServiceCollection services, Type sharedResource)
        {
            builder.AddDataAnnotationsLocalization(Options =>
            {
                var localizer = new FactoryLocalizer().Set(services, sharedResource);
                Options.DataAnnotationLocalizerProvider = (t, f) => localizer;
            });
            return builder;
        }

        public static IServiceCollection AddInject(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizer, Localizer>();
            services.AddSingleton<IMsgBox, MsgBox>();
            return services;
        }

      
    }
}
