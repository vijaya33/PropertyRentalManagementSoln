using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertyRentalManagement.Core.Entities;

public class Unit
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public decimal MonthlyRent { get; set; }
    public bool IsOccupied { get; set; }

    public Property? Property { get; set; }
    public ICollection<Lease> Leases { get; set; } = new List<Lease>();
}