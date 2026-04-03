using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRentalManagement.Core.Entities;

public class Lease
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int TenantId { get; set; }
    public DateTime LeaseStartDate { get; set; }
    public DateTime LeaseEndDate { get; set; }
    public decimal MonthlyRent { get; set; }
    public decimal SecurityDeposit { get; set; }
    public bool IsActive { get; set; }

    public Unit? Unit { get; set; }
    public Tenant? Tenant { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}