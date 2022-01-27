using System;


namespace RYXTravelAgency.Shared.Domain
{
    public class Booking : BaseDomainModel
    {

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
 