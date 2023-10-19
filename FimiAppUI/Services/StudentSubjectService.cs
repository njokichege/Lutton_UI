namespace FimiAppUI.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly HttpClient _httpClient;

        public StudentSubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassSubjectList>>($"api/studentsubject/mapstudentonsubject/{classId}");
        }
        public async Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<List<StudentSubjectModel>>($"api/studentsubject/subjectsbystudentnumber/{studentNumber}");
        }
        public async Task<HttpResponseMessage> AddStudentSubject(StudentSubjectModel studentSubjectModel)
        {
            return await _httpClient.PostAsJsonAsync<StudentSubjectModel>("api/studentsubject", studentSubjectModel);
        }
        public async Task<StudentSubjectModel> FindEntry(int studentNumber, int code)
        {
            return await _httpClient.GetFromJsonAsync<StudentSubjectModel>($"api/studentsubject/findentry/{studentNumber}/{code}");
        }
    }
}
