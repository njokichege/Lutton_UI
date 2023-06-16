using FimiAppApi.Contracts;
using FimiAppApi.Repository;

namespace FimiAppUI
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ISqlDbConnection, SqlDbConnection>();
            builder.Services.AddScoped<IStudentData, StudentData>();
            builder.Services.AddScoped<IStreamData,StreamData>();
            builder.Services.AddScoped<IFormData, FormData>();
            builder.Services.AddScoped<ISessionYearData, SessionYearData>();
            builder.Services.AddScoped<DapperContext>();
            builder.Services.AddScoped<IClassData, ClassData>();
        }
    }
}
