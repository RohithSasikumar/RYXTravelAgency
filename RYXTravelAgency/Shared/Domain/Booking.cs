using System;

namespace RYXTravelAgency.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int Total_seats { get; set; }
        public DateTime Depart_time { get; set; }
        public DateTime Arrive_time { get; set; }
    }
}
 