using FimiAppUI.Contracts;
using System.Net.Http;

namespace FimiAppUI.Services
{
    public class FormService : IFormService
    {
        private readonly HttpClient httpClient;

        public FormService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<FormModel>> GetForms()
        {
            return await httpClient.GetFromJsonAsync<FormModel[]>("api/form");
        }
        public async Task<FormModel> GetFormById(int formId)
        {
            return await httpClient.GetFromJsonAsync<FormModel>($"api/form/{formId}");
        }
        public async Task<int> GetFormByName(string formName)
        {
            return await httpClient.GetFromJsonAsync<int>($"api/form/formbyname/{formName}");
        }
    }
}
