namespace FimiAppUI.Services
{
    public class ClassService : IClassService
    {
        private readonly HttpClient httpClient;

        public ClassService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            return await httpClient.GetFromJsonAsync<ClassModel[]>("api/class");
        }
    }
}
