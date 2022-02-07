using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RYXTravelAgency.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name does not meet length requirements")]
        public string Name { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Phone Number is not valid")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not valid")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
}