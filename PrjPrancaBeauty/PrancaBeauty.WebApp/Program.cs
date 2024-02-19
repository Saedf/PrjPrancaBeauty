using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.Extensions.WebEncoders;
using PrancaBeauty.WebApp.Config;
using PrancaBeauty.WebApp.Localization.Resource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization("Localization/Resource");
builder.Services.WebEncoderConfig();
builder.Services.AddRazorPage()
    .AddCustomViewLocalization("Localization/Resource")
    .AddCustomDataAnotaionLocalization(builder.Services, typeof(SharedResource));

builder.Services.AddInject();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
