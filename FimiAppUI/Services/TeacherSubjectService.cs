﻿namespace FimiAppUI.Services
{
    public class TeacherSubjectService : ITeacherSubjectService
    {
        private readonly HttpClient _httpClient;

        public TeacherSubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TeacherSubjectModel>> GetMultipleMapping()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeacherSubjectModel>>("api/teachersubject/multiplemapping");
        }
        public async Task<IEnumerable<TeacherSubjectModel>> GetMultipleMappingByTeacher(int teacherId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeacherSubjectModel>>($"api/teachersubject/mapstudentonteacher/{teacherId}");
        }
        public async Task<HttpResponseMessage> CreateTeacherSubject(TeacherSubjectModel teacherSubjectModel)
        {
            return await _httpClient.PostAsJsonAsync<TeacherSubjectModel>("api/teachersubject", teacherSubjectModel);
        }
    }
}
