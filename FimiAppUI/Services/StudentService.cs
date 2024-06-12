namespace FimiAppUI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
            return await _httpClient.GetFromJsonAsync<StudentModel[]>("api/student");
        }
        public async Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId)
        {
            return await _httpClient.GetFromJsonAsync< IEnumerable<StudentModel>> ($"api/student/class/{classId}");
        }
        public async Task<IEnumerable<StudentModel>> GetAllStudentsBySessionYear(int sesionYearId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StudentModel>>($"api/student/allstudents/{sesionYearId}");
        }
        public async Task<StudentModel> GetStudentByStudentNumber(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<StudentModel>($"api/student/{studentNumber}");
        }
        public async Task<HttpResponseMessage> AddStudent(StudentModel student)
        {
            return await _httpClient.PostAsJsonAsync<StudentModel>("api/student",student);
        }
        public async Task<HttpResponseMessage> AddExistingStudent(StudentModel student)
        {
            return await _httpClient.PostAsJsonAsync<StudentModel>("api/student/existingstudent", student);
        }
    }
}
