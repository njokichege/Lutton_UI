namespace FimiAppUI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly HttpClient _httpClient;

        public SubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SubjectModel>> GetSubjects()
        {
            return await _httpClient.GetFromJsonAsync<SubjectModel[]>("api/subject");
        }
        public async Task<IEnumerable<SubjectModel>> GetAcademicSubjects()
        {
            return await _httpClient.GetFromJsonAsync<SubjectModel[]>("api/subject/getacademicsubjects");
        }
        public async Task<HttpResponseMessage> CreateSubject(SubjectModel subjectModel)
        {
            return await _httpClient.PostAsJsonAsync<SubjectModel>("api/subject", subjectModel);
        }
        public async Task<IEnumerable<SubjectModel>> MapSubjectOnCategory()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SubjectModel>>("api/subject/mapsubjectoncategory");
        }
    }
}
