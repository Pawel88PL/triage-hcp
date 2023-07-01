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
        [StringLength(150)]
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

        public string? Allergies { get; set; }


        [Range(0, 300, ErrorMessage = "Ciśnienie skurczowe (SBP) musi być między 0 a 300.")]
        public int SBP { get; set; }

        [Range(0, 200, ErrorMessage = "Ciśnienie rozkurczowe (DBP) musi być między 0 a 200.")]
        public int DBP { get; set; }

        [Range(0, 300, ErrorMessage = "Częstość uderzeń serca (HeartRate) musi być między 0 a 300.")]
        public int HeartRate { get; set; }

        [Range(0, 100, ErrorMessage = "Saturacja (Spo2) musi być między 0 a 100.")]
        public int Spo2 { get; set; }

        [Range(3, 15, ErrorMessage = "Skala Glasgow (GCS) musi być między 3 a 15.")]
        public int GCS { get; set; }

        [Range(34.0, 43.0, ErrorMessage = "Temperatura ciała musi być między 34.0 a 43.0.")]
        public double BodyTemperature { get; set; }
    }
}
