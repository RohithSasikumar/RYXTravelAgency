using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RYXTravelAgency.Client.Static
{
    public static class Endpoints
    {
        public static readonly string Prefix = "api";
        public static readonly string DeparturesEndpoint = $"{Prefix}/departures";
        public static readonly string ModelsEndpoint = $"{Prefix}/models";
        public static readonly string ArrivalsEndpoint = $"{Prefix}/arrivals";
        public static readonly string FlightsEndpoint = $"{Prefix}/flights";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string BookingsEndpoint = $"{Prefix}/bookings";
    }
}

