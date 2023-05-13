using System.ComponentModel.DataAnnotations;

namespace FimiAppUI.Models
{
    public class DisplayStudentModel
    {
        public int StudentNumber { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "First name is too long")]
        [MinLength(5, ErrorMessage = "First name is too short")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Middle name is too long")]
        [MinLength(5, ErrorMessage = "Middle name is too short")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Surname name is too long")]
        [MinLength(5, ErrorMessage = "Surname name is too short")]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int ParentId { get; set; }
    }
}
