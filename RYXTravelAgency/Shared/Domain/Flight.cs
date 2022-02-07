using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RYXTravelAgency.Shared.Domain
{
    public class Flight : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public double TicketPrice { get; set; }

        [Required]
        public int? Available_Seats { get; set; }

        [Required]
        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }

        [Required]
        public int? DepartureId { get; set; }
        public virtual Departure Departure { get; set; }

        [Required]
        public int? ArrivalId { get; set; }
        public virtual Arrival Arrival { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
