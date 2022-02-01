using System.Collections.Generic;

namespace RYXTravelAgency.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
}