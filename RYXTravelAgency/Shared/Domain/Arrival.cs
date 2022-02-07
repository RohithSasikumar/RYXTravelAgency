using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RYXTravelAgency.Shared.Domain
{
    public class Arrival : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Arriv_Location { get; set; }
    }
}
