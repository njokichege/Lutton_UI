using FimiAppApi.Repository;

namespace FimiAppApi
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddSingleton<IClassRepository, ClassRepository>();
            builder.Services.AddSingleton<IFormRepository, FormRepository>();
            builder.Services.AddSingleton<IStreamRepository, StreamRepository>();
            builder.Services.AddSingleton<ISessionYearRepository, SessionYearRepository>();
            builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
            builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
            builder.Services.AddSingleton<IParentRepository, ParentRepository>();
            builder.Services.AddSingleton<IParentStudentRepository, ParentStudentRepository>();
            builder.Services.AddSingleton<ISubjectRepository, SubjectRepository>();
            builder.Services.AddSingleton<ITeacherSubjectRepository, TeacherSubjectRepository>();
            builder.Services.AddSingleton<ISubjectCategoryRepository, SubjectCategoryRepository>();
            builder.Services.AddSingleton<IStudentSubjectRepository, StudentSubjectRepository>();
            builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
            builder.Services.AddSingleton<IGradeRepository, GradeRepository>();
        }
    }
}
