namespace FimiAppLibrary.Models
{
    public class SessionYearModel
    {
        public int SessionYearId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionString()
        {
            return $"{StartDate.ToString("MMMM yyyy")} - {EndDate.ToString("MMMM yyyy")}";
        }

    }
}
