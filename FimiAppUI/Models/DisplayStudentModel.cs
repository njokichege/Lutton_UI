using System.ComponentModel.DataAnnotations;

namespace FimiAppUI.Models
{
    public class DisplayStudentModel
    {
        [Required]
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int ParentId { get; set; }
    }
}
