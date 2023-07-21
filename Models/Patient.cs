using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace triage_hcp.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Podaj imię pacjenta lub wpisz NN.")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko pacjena lub wpisz NN.")]
        [MaxLength(30)]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Jeśli brak nr PESEL, wpisz datę urodzenia w formacie DD-MM-RRRR")]
        [StringLength(11)]
        public string? Pesel { get; set; }

        [Required(ErrorMessage = "Napisz kilka słów na temat stanu lub objawów pacjenta")]
        [StringLength(130)]
        public string? Symptoms { get; set; }

        public string? Age { get; set; }
        
        public string? Gender { get; set; }

        public string? Color { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime StartDiagnosis { get; set; }

        public bool IsActive { get; set; }

        public string? Remarks { get; set; }

        public string? WhatNext { get; set; }

        public string? ToWhomThePatient { get; set; }

        public DateTime EndTime { get; set; }

        public int WaitingTime { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal TotalTime { get; set; }

        [StringLength(30)]
        public string? Allergies { get; set; }

        [Range(0, 400)]
        public int? SBP { get; set; }

        [Range(0, 200)]
        public int? DBP { get; set; }

        [Range(0, 300)]
        public int? HeartRate { get; set; }

        [Range(0, 100)]
        public int? Spo2 { get; set; }

        [Range(3, 15)]
        public int? GCS { get; set; }

        [Column(TypeName = "decimal(3,1)")]
        [Range(15, 45)]
        public decimal BodyTemperature { get; set; }



        // Klucze obce do tabel Location i Doctors.

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
