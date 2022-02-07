using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RYXTravelAgency.Shared.Domain
{
    public class Booking : BaseDomainModel, IValidatableObject
    {
        [Required]
        public int? FlightId { get; set; }
        public virtual Flight Flight { get; set; }     
        
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public int? Total_seats { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Depart_time { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Arrive_time { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Arrive_time <= Depart_time)
            {
                yield return new ValidationResult("Arrive Time must be greater than Depart Time", new[] { "Arrive_time" });
            }
       

        }
    }
}
 