using Microsoft.AspNetCore.Mvc;

namespace FimiAppUI.Contracts
{
    public interface IReportService
    {
        Task<HttpResponseMessage> GenerateReportCard(int studentNumber, string sessionYearId, string termId, string examTypeId);
        Task<byte[]> StudentReportCardBytes(int studentNumber, string sessionYearId, string termId, string examTypeId);
    }
}