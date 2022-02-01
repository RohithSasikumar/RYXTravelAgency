using System.Collections.Generic;

namespace RYXTravelAgency.Shared.Domain
{
    public class Flight : BaseDomainModel
    {
        public int Available_Seats { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int DepartureId { get; set; }
        public virtual Departure Departure { get; set; }
        public int ArrivalId { get; set; }
        public virtual Arrival Arrival { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
