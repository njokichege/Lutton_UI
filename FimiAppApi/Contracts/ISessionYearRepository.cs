﻿namespace FimiAppApi.Contracts
{
    public interface ISessionYearRepository
    {
        Task<SessionYearModel> CreateSessionYear(SessionYearModel sessionYear);
        Task<SessionYearModel> GetSessionYearByDates(SessionYearModel sessionYear);
        Task<SessionYearModel> GetSessionYearById(int sessionId);
        Task<int> GetSessionYearByStartDate(DateTime dateTime);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
