namespace FimiAppLibrary.Models
{
    public class SessionYearModel
    {
        public int SessionYearId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionString()
        {
            return $"{StartDate.Month}/{StartDate.Year} - {EndDate.Month}/{EndDate.Year}";
        }

    }
}
