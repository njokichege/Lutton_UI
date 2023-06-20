using FimiAppApi.Contracts;
using FimiAppApi.Repository;
using FimiAppUI.Services;

namespace FimiAppUI
{
    public static class RegisterServices
    {
        static private readonly string uriLink = "https://localhost:7263/";
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient<IClassService, ClassService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IFormService, FormService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IStreamService, StreamService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ISessionYearService, SessionYearService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITeacherService, TeacherService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
        }
    }
}
