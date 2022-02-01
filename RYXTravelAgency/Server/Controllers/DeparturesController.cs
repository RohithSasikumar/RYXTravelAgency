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
    public class DeparturesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public DeparturesController(ApplicationDbContext context)
        public DeparturesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Departures
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Departure>>> GetDepartures()
        public async Task<IActionResult> GetDepartures()
        {
            //Refactored
            //return await _context.Departures.ToListAsync();
            var departures = await _unitOfWork.Departures.GetAll();
            return Ok(departures);
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Departure>> GetDeparture(int id)
        public async Task<IActionResult> GetDeparture(int id)
        {
            //Refactored
            //var departure = await _context.Departures.FindAsync(id);
            var departure = await _unitOfWork.Departures.Get(q => q.Id == id);

            if (departure == null)
            {
                return NotFound();
            }

            //Refactored
            //return departure;
            return Ok(departure);
        }

        // PUT: api/Departures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeparture(int id, Departure departure)
        {
            if (id != departure.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(departure).State = EntityState.Modified;
            _unitOfWork.Departures.Update(departure);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!DepartureExists(id))
                if (!await DepartureExists(id))
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

        // POST: api/Departures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departure>> PostDeparture(Departure departure)
        {
            //Refactored
            //_context.Departures.Add(departure);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Departures.Insert(departure);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDeparture", new { id = departure.Id }, departure);
        }

        // DELETE: api/Departures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeparture(int id)
        {
            //Refactored
            //var departure = await _context.Departures.FindAsync(id);
            var departure = await _unitOfWork.Departures.Get(q => q.Id == id);
            if (departure == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Departures.Remove(departure);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Departures.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool DepartureExists(int id)
        private async Task<bool> DepartureExists(int id)
        {
            //Refactored
            //return _context.Departures.Any(e => e.Id == id);
            var departure = await _unitOfWork.Departures.Get(q => q.Id == id);
            return departure != null;
        }
    }
}
