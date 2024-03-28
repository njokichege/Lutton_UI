using Microsoft.AspNetCore.Mvc;

namespace FimiAppUI.Contracts
{
    public interface IReportService
    {
        Task<byte[]> StudentReportCardBytes(int studentNumber, string sessionYearId, string termId, string examTypeId);
    }
}