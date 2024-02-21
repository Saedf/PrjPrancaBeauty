using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PrancaBeauty.WebApp.Authentication
{
    public static class ConfigIdentityJwt
    {
        private static string _secretKey;
        private static byte[] _secretCode;
        public static void AddJwtAuthentication(this IServiceCollection services, string secretCode, string secretKey, string audience, string issuer)
        {
            _secretKey = secretKey;
            _secretCode = Encoding.ASCII.GetBytes(secretCode);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme); 
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {

                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_secretCode),

                        RequireExpirationTime = true,
                        ValidateLifetime = true,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        ValidateIssuer = true,
                        ValidIssuer = issuer
                    };
                });
        }

        public static void UseJwtAuthentication(this IApplicationBuilder app, string cookieName)
        {
            app.UseMiddleware<JwtAuthenticationWebAppMiddleware>(_secretKey, cookieName);

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
