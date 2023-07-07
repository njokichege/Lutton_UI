using FimiAppApi;
using FimiAppApi.Repository;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSingleton<ITeacherRepository,  TeacherRepository>();
builder.Services.AddSingleton<IStudentRepository,  StudentRepository>();
builder.Services.AddSingleton<IParentRepository, ParentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
