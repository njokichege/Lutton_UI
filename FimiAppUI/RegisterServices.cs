using FimiAppApi.Contracts;
using FimiAppApi.Repository;
using FimiAppUI.Contracts;

namespace FimiAppUI
{
    public static class RegisterServices
    {
        static private readonly string uriLink = "https://localhost:5124/";
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<Radzen.DialogService>();

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
            builder.Services.AddHttpClient<IStudentService, StudentService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IParentService, ParentService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IParentStudentService, ParentStudentService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IStaffService, StaffService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ISubjectService, SubjectService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITeacherSubjectService, TeacherSubjectService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ISubjectCategoryService, SubjectCategoryService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IStudentSubjectService, StudentSubjectService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IStaffService, StaffService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IGradeService, GradeService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ISchoolPerformanceService, SchoolPerformanceService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IClassPerformanceService, ClassPerformanceService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITermService, TermService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IExamTypeService, ExamTypeService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITimeSlotService, TimeSlotService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITimetableService, TimetableService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ITimetableTeacherSubjectService, TimetableTeacherSubjectService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IStudentClassService, StudentClassService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ILabService, LabService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<ILabSubjectService, LabSubjectService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IExamResultService, ExamResultService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IEventService, EventService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
            builder.Services.AddHttpClient<IEventTypeService, EventTypeService>(client =>
            {
                client.BaseAddress = new Uri(uriLink);
            });
        }
    }
}
