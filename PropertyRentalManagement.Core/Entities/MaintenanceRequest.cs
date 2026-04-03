using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRentalManagement.Core.Entities;

public class MaintenanceRequest
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public int UnitId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public string Status { get; set; } = "Open";
    public string Priority { get; set; } = "Medium";

    public Tenant? Tenant { get; set; }
    public Unit? Unit { get; set; }
}