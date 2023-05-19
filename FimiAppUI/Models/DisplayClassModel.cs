using System.ComponentModel.DataAnnotations;

namespace FimiAppUI.Models
{
    public class DisplayClassModel
    {
        [Required]
        public int ClassId { get; set; }
        public int Form { get; set; }
        public string Stream { get; set; }
        public string SessionYear { get; set; }
        public int Capacity { get; set; }
        public int ClassTeacher { get; set; }
        public int GradeId { get; set; }
    }
}
