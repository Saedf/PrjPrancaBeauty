using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using FrameWork.Application.Consts;
using Microsoft.Extensions.WebEncoders;
using PrancaBeauty.Infrastructure.Core.Configuration;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Config;
using PrancaBeauty.WebApp.Localization.Resource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization("Localization/Resource");
builder.Services.WebEncoderConfig();
builder.Services.AddRazorPage()
    .AddCustomViewLocalization("Localization/Resource")
    .AddCustomDataAnotaionLocalization(builder.Services, typeof(SharedResource));

builder.Services.Config();

builder.Services.AddInject();
    
builder.Services.AddCustomIdentity()
    .AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddJwtAuthentication(AuthConst.SecretCode,AuthConst.SecretKey,AuthConst.Audience,AuthConst.Issuer); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseLocalization(new List<CultureInfo>()
{
    new CultureInfo("en-Us"),
    new CultureInfo("fa-IR"),

}, "fa-IR");

app.UseRouting();

//*******added my self
app.UseJwtAuthentication(AuthConst.CookieName);
//******************

//app.UseAuthorization();


app.MapRazorPages();

app.Run();
