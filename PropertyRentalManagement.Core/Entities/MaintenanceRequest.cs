//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PropertyRentalManagement.Core.Entities;

//public class MaintenanceRequest
//{
//    public int Id { get; set; }
//    public int TenantId { get; set; }
//    public int UnitId { get; set; }
//    public string Title { get; set; } = string.Empty;
//    public string Description { get; set; } = string.Empty;
//    public DateTime RequestDate { get; set; }
//    public string Status { get; set; } = "Open";
//    public string Priority { get; set; } = "Medium";

//    public Tenant? Tenant { get; set; }
//    public Unit? Unit { get; set; }
//}

using PropertyRentalManagement.Core.Entities;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace PropertyRentalManagement.Core.Entities
{
    public class MaintenanceRequest
    {
        public int MaintenanceRequestId { get; set; }

        [Required(ErrorMessage = "Please select a property.")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Please select a tenant.")]
        public int TenantId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Priority { get; set; } = "Medium";

        [Required]
        public string Status { get; set; } = "Open";

        public string? AssignedTo { get; set; }

        public DateTime RequestedDate { get; set; } = DateTime.Now;

        public DateTime? ScheduledDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? EstimatedCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualCost { get; set; }

        [StringLength(1000)]
        public string? ResolutionNotes { get; set; }

        public Property? Property { get; set; }

        public Tenant? Tenant { get; set; }
    }
}