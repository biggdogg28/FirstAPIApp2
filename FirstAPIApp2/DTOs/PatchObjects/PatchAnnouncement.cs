using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstAPIApp2.DTOs.PatchObjects
{
    public class PatchAnnouncement
    {
        [Key]
        [JsonIgnore]
        public Guid IDAnnouncement { get; set; }
        
        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public string? Title { get; set; }

        public string? Text { get; set; }

        public DateTime? EventDate { get; set; }

        public string? Tags { get; set; }
    }
}
