﻿using Microsoft.AspNetCore.Mvc;

namespace FimiAppUI.Contracts
{
    public interface IReportService
    {
        Task<HttpResponseMessage> AllStudentReportCards([FromBody] List<int> studentNumbers, string sessionYearId, string termId, string examTypeId);
        Task<byte[]> StudentReportCardBytes(int studentNumber, string sessionYearId, string termId, string examTypeId);
    }
}