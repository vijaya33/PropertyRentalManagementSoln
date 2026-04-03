using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRentalManagement.Core.Entities;

public class Payment
{
    public int Id { get; set; }
    public int LeaseId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = "Completed";

    public Lease? Lease { get; set; }
}