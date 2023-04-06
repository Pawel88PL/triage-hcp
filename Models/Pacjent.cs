using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace triage_hcp.Models
{
    public class Pacjent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj imię pacjenta lub wpisz NN.")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko pacjena lub wpisz NN.")]
        [MaxLength(30)]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Podaj nr PESEL")]
        [StringLength(11, ErrorMessage = "Jeśli brak nr PESEL, wpisz datę urodzenia w formacie DD-MM-RRRRr. " +
            " Jeśli brak nr PESEL i daty urodzenia, wypisz jedenaście zer (00000000000). ", MinimumLength = 11 )]
        public string? Pesel { get; set; }

        [Required(ErrorMessage = "Podaj wiek pacjenta")]
        [Range(1,120, ErrorMessage = "Wiek pacjenta może mieścić się w zakresie od 1 do 120 lat.")]
        public string? Age { get; set; }

        [Required(ErrorMessage = "Płeć jest wymagana")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Sala i numer jest wymagana")]
        public string? Room { get; set; }

        [Required(ErrorMessage = "Napisz kilka słów na temat stanu lub objawów pacjenta")]
        [StringLength(100, ErrorMessage = "Opis wymaga użycia minimum 10 znaków.", MinimumLength = 10)]
        public string? Diagnosis { get; set; }

        
        public string? Color { get; set; }
        
        public DateTime DateTime { get; set ; }

        public string? Doctor { get; set; }
        
        public string? Active { get; set; }

        public string? Epikryza { get; set; }

        public string? ObserwacjeRatPiel { get; set; }

        public string? CoDalejZPacjentem { get; set; }
    }
}
