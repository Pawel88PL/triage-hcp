using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Jeśli brak nr PESEL, wpisz datę urodzenia w formacie DD-MM-RRRR")]
        [StringLength(11)]
        public string? Pesel { get; set; }

        public string? Age { get; set; }

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Sala i numer jest wymagana")]
        public string? Room { get; set; }

        [Required(ErrorMessage = "Napisz kilka słów na temat stanu lub objawów pacjenta")]
        [StringLength(130)]
        public string? Diagnosis { get; set; }


        public string? Color { get; set; }

        public DateTime DateTime { get; set; }


        public string? Doctor { get; set; }


        public string? Active { get; set; }

        public string? Epikryza { get; set; }

        public string? ObserwacjeRatPiel { get; set; }

        public string? CoDalejZPacjentem { get; set; }

        public DateTime TriageDate { get; set; }

        public string? ToWhomThePatient { get; set; }

        public DateTime EndTime { get; set; }

        public int WaitingTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalTime { get; set; }

        [StringLength(30)]
        public string? Allergies { get; set; }

        [StringLength(3)]
        public string? SBP { get; set; }

        [StringLength(3)]
        public string? DBP { get; set; }

        [StringLength(3)]
        public string? HeartRate { get; set; }

        [StringLength(3)]
        public string? Spo2 { get; set; }

        [StringLength(2)]
        public string? GCS { get; set; }

        [StringLength(3)]
        public string? BodyTemperature { get; set; }
    }
}
