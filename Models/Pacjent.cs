using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace triage_hcp.Models
{
    public class Pacjent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "PESEL jest wymagany")]
        public string? Pesel { get; set; }

        [Required(ErrorMessage = "Wiek jest wymagany")]
        public string? Age { get; set; }

        [Required(ErrorMessage = "Płeć jest wymagana")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Sala i numer jest wymagana")]
        public string? Room { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        public string? Diagnosis { get; set; }

        [Required(ErrorMessage = "Kolor jest wymagany")]
        public string? Color { get; set; }
        
        public DateTime DateTime { get; set ; }

        
        public string? Doctor { get; set; }

        
        public string? Active { get; set; }

        public string? Epikryza { get; set; }

        public string? ObserwacjeRatPiel { get; set; }

        public string? CoDalejZPacjentem { get; set; }
    }
}
