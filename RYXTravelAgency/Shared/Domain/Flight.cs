using System;
using System.Collections.Generic;


namespace RYXTravelAgency.Shared.Domain
{
    public class Flight : BaseDomainModel
    {
        public int Airline_id { get; set; }
        public string Airline_name { get; set; }
        public string Start_location { get; set; }
        public string End_location { get; set; }
        public DateTime Depart_time { get; set; }
        public DateTime Arrive_time { get; set; }
        public int Total_seats { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
