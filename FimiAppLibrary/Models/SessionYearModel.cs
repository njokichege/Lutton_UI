namespace FimiAppLibrary.Models
{
    public class SessionYearModel
    {
        public int SessionYearId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionString
        {
            get
            {
                return this._sessionString;
            }
            set
            {
                _sessionString = $"{StartDate.Month}/{StartDate.Year} - {EndDate.Month}/{EndDate.Year}";
            }
        }
        private string _sessionString;
    }
}
