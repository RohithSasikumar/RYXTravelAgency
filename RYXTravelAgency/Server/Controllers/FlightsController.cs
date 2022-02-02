using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RYXTravelAgency.Server.Data;
using RYXTravelAgency.Server.IRepository;
using RYXTravelAgency.Shared.Domain;

namespace RYXTravelAgency.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public FlightsController(ApplicationDbContext context)
        public FlightsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Flights
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        public async Task<IActionResult> GetFlights()
        {
            //Refactored
            //return await _context.Flights.ToListAsync();
            var Flights = await _unitOfWork.Flights.GetAll(includes: q => q.Include(x => x.Model).Include(x => x.Arrival).Include(x => x.Departure));
            return Ok(Flights);
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Flight>> GetFlight(int id)
        public async Task<IActionResult> GetFlight(int id)
        {
            //Refactored
            //var Flight = await _context.Flights.FindAsync(id);
            var Flight = await _unitOfWork.Flights.Get(q => q.Id == id);

            if (Flight == null)
            {
                return NotFound();
            }

            //Refactored
            //return Flight;
            return Ok(Flight);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight Flight)
        {
            if (id != Flight.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Flight).State = EntityState.Modified;
            _unitOfWork.Flights.Update(Flight);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!FlightExists(id))
                if (!await FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight Flight)
        {
            //Refactored
            //_context.Flights.Add(Flight);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Flights.Insert(Flight);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFlight", new { id = Flight.Id }, Flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            //Refactored
            //var Flight = await _context.Flights.FindAsync(id);
            var Flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            if (Flight == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Flights.Remove(Flight);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Flights.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool FlightExists(int id)
        private async Task<bool> FlightExists(int id)
        {
            //Refactored
            //return _context.Flights.Any(e => e.Id == id);
            var Flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            return Flight != null;
        }
    }
}
