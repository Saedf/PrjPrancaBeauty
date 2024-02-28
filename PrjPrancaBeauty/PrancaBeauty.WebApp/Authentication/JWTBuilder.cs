using FrameWork.Application.Consts;
using FrameWork.Common.ExMethods;
using Microsoft.IdentityModel.Tokens;
using PrancaBeauty.Application.Apps.Users;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PrancaBeauty.Application.Apps.Roles;

namespace PrancaBeauty.WebApp.Authentication
{
    public class JWTBuilder:IJWTBuilder
    {
        private readonly IUserApplication _UserApplication;
        private readonly IRoleApplication _roleApplication;

        public JWTBuilder(IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _UserApplication = userApplication;
            _roleApplication = roleApplication;
        }

        //  private readonly IRoleApplication _RoleApplication;
        public async Task<string> CreateTokenAync(string UserId)
        {
            var userDetails = await _UserApplication.GetAllUserDetailsAsync( UserId );
            if (userDetails == null)
                throw new Exception();

            var _UserRoles = await _roleApplication.GetRolesByUserAsync(UserId);
            if (_UserRoles == null)
                throw new Exception();

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userDetails.Id.ToString()),
                new Claim(ClaimTypes.Name, userDetails.UserName),
                new Claim(ClaimTypes.Email, userDetails.Email),
                new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber??""),
                new Claim(ClaimTypes.GivenName, userDetails.FirstName),
                new Claim(ClaimTypes.Surname, userDetails.LastName),
                new Claim("AccessLevel", userDetails.AccessLevelTitle),
             //   new Claim("SellerId", userDetails.SellerId??""),
                new Claim("Date", userDetails.Date.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"))),
            };

          //  Claims.AddRange(_UserRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var _Key = Encoding.ASCII.GetBytes(AuthConst.SecretCode);
            var TokenDescreptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_Key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = AuthConst.Issuer,
                Audience = AuthConst.Audience,
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(48)
            };

            var _SecurityToken = new JwtSecurityTokenHandler().CreateToken(TokenDescreptor);
            string _GeneratedToken = "Bearer " + new JwtSecurityTokenHandler().WriteToken(_SecurityToken);

            return _GeneratedToken.AesEncrypt(AuthConst.SecretKey);
        }
    }
}
