using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstAPIApp2.DTOs.CreateUpdateObjects
{
    // Create a minimal model
    // The JsonIgnore will ignore the ID before sending the body for update
    public class CreateUpdateAnnouncement
    {
        [Key]
        [JsonIgnore]
        public Guid IDAnnouncement { get; set; }
        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime? ValidFrom { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime? ValidTo { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(251, ErrorMessage = "Title field can be 250 characters maximum.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Text field must be between 5 and 250 characters.")]

        public string Text { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        [StringLength(1000, ErrorMessage = "Tags field can be 1000 characters maximum.")]
        public string Tags { get; set; }
    }
}
