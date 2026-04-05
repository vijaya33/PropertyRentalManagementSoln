using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Core.Entities
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Property Name is required.")]
        [StringLength(150)]
        public string PropertyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address Line 1 is required.")]
        [StringLength(200)]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(200)]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip Code is required.")]
        [StringLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Total Units must be at least 1.")]
        public int TotalUnits { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Please select a landlord.")]
        [Required(ErrorMessage = "Please select a landlord.")]
        public int? LandlordId { get; set; }

        public Landlord? Landlord { get; set; }

        public ICollection<Unit> Units { get; set; } = new List<Unit>();
    }
}