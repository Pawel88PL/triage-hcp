using System.ComponentModel.DataAnnotations;

namespace triage_hcp.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string? LocationName { get; set; }

        public bool IsAvailable { get; set; }

    }
}
