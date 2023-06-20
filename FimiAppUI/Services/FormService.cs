namespace FimiAppUI.Services
{
    public class FormService : IFormService
    {
        private readonly HttpClient httpClient;

        public FormService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FormModel>> GetClassFormMapping()
        {
            return await httpClient.GetFromJsonAsync<FormModel[]>("api/form");
        }

        public async Task<IEnumerable<FormModel>> GetForms()
        {
            return await httpClient.GetFromJsonAsync<FormModel[]>("api/form");
        }
    }
}
