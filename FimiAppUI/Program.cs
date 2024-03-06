using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FimiAppUI;
using MudBlazor.Services;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();
builder.Services.AddMudServices();
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
    options.HttpsPort = 8080; // Set your desired HTTPS port here
});
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseDeveloperExceptionPage();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
