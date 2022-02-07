using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RYXTravelAgency.Shared.Domain
{
    public class Departure : BaseDomainModel
    {
        [Required]
        public string Depart_Location { get; set; }
    }
}
