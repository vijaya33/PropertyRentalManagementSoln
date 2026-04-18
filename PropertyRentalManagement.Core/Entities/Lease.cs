using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Core.Entities
{
    public class Lease
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a tenant.")]
        public int? TenantId { get; set; }

        [Required(ErrorMessage = "Please select a property.")]
        public int? PropertyId { get; set; }

        [Required(ErrorMessage = "Monthly Rent is required.")]
        [Range(1, 100000, ErrorMessage = "Monthly Rent must be at least 1.")]
        public decimal MonthlyRent { get; set; }

        [Required(ErrorMessage = "Security Deposit is required.")]
        [Range(0, 100000, ErrorMessage = "Security Deposit cannot be negative.")]
        public decimal SecurityDeposit { get; set; }

        [Required(ErrorMessage = "Lease Start Date is required.")]
        public DateTime LeaseStartDate { get; set; }

        [Required(ErrorMessage = "Lease End Date is required.")]
        public DateTime LeaseEndDate { get; set; }

        public Tenant? Tenant { get; set; }
        public Property? Property { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}