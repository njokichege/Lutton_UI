namespace FimiAppUI
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
            builder.Services.AddTransient<ISqlDbConnection, SqlDbConnection>();
            builder.Services.AddTransient<IStudentData, StudentData>();
            builder.Services.AddTransient<IStreamData,StreamData>();
            builder.Services.AddTransient<IFormData, FormData>();
            builder.Services.AddTransient<ISessionYearData, SessionYearData>();
        }
    }
}
