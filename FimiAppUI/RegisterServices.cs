using FimiAppApi.Contracts;
using FimiAppApi.Repository;
using FimiAppUI.Services;

namespace FimiAppUI
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient<IClassService, ClassService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7263/");
            });
            builder.Services.AddHttpClient<IFormService, FormService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7263/");
            });

        }
    }
}
