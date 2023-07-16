using System.ComponentModel.DataAnnotations;

namespace triage_hcp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Surname { get; set; }

        
        [MaxLength(7)] // PWZ Number is 7 digits
        public string? PWZNumber { get; set; }
    }
}
