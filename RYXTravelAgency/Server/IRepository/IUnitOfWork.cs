using RYXTravelAgency.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RYXTravelAgency.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Departure> Departures { get; }
        IGenericRepository<Model> Models { get; }
        IGenericRepository<Flight> Flights { get; }
        IGenericRepository<Arrival> Arrivals { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}