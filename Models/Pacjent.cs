using System.Text.Json.Serialization;

namespace triage_hcp.Models
{
    public class Pacjent
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Pesel { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Room { get; set; }
        public string? Diagnosis { get; set; }
        public string? Color { get; set; }
        public DateTime DateTime
        {
            get { return DateTime.Now; }
        }
        public string? Doctor { get; set; }
        public string? Active { get; set; }
    }
}
