using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Core.Entities;

public class Landlord
{
    public int Id { get; set; }

     [Required(ErrorMessage = "Landlord full name is required.")]
     [StringLength(75)]
    public string FullName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    // Optional: Use Regex for a specific 10-digit format
   //  [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter a 10-digit number.")]
   
    [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Invalid Phone Number!, required format is 111-222-9999")]

    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<Property> Properties { get; set; } = new List<Property>();
}