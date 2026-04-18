using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Core.Entities
{
    public class PropertyPhoto
    {
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ContentType { get; set; } = string.Empty;

        [Required]
        public byte[] PhotoData { get; set; } = Array.Empty<byte>();

        public DateTime UploadedOn { get; set; } = DateTime.UtcNow;

        public Property? Property { get; set; }
    }
}