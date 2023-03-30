using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace triage_hcp.Models
{
    public class Pacjent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj imię pacjenta lub wpisz NN")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko pacjena lub wpisz NN")]
        [MaxLength(30)]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Podaj nr PESEL")]
        [MaxLength(11)]
        [Range(10000000000, 99999999999, ErrorMessage = "PESEL składa się z 11 cyfr, jeśli brak - wpisz same jedynki")]
        public string? Pesel { get; set; }

        [Required(ErrorMessage = "Podaj wiek pacjenta")]
        [Range(1,120, ErrorMessage = "Wiek pacjenta może mieścić się w zakresie od 1 do 120 lat")]
        public string? Age { get; set; }

        [Required(ErrorMessage = "Płeć jest wymagana")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Sala i numer jest wymagana")]
        public string? Room { get; set; }

        [Required(ErrorMessage = "Napisz kilka słów na temat stanu lub objawów pacjenta")]
        [StringLength(100, ErrorMessage = "Wyśil się trochę bardziej :)", MinimumLength = 10)]
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
