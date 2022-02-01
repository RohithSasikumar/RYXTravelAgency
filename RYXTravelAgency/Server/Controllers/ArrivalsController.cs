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
    public class ArrivalsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ArrivalsController(ApplicationDbContext context)
        public ArrivalsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Arrivals
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Arrival>>> GetArrivals()
        public async Task<IActionResult> GetArrivals()
        {
            //Refactored
            //return await _context.Arrivals.ToListAsync();
            var Arrivals = await _unitOfWork.Arrivals.GetAll();
            return Ok(Arrivals);
        }

        // GET: api/Arrivals/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Arrival>> GetArrival(int id)
        public async Task<IActionResult> GetArrival(int id)
        {
            //Refactored
            //var Arrival = await _context.Arrivals.FindAsync(id);
            var Arrival = await _unitOfWork.Arrivals.Get(q => q.Id == id);

            if (Arrival == null)
            {
                return NotFound();
            }

            //Refactored
            //return Arrival;
            return Ok(Arrival);
        }

        // PUT: api/Arrivals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrival(int id, Arrival Arrival)
        {
            if (id != Arrival.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Arrival).State = EntityState.Modified;
            _unitOfWork.Arrivals.Update(Arrival);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ArrivalExists(id))
                if (!await ArrivalExists(id))
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

        // POST: api/Arrivals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arrival>> PostArrival(Arrival Arrival)
        {
            //Refactored
            //_context.Arrivals.Add(Arrival);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Arrivals.Insert(Arrival);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetArrival", new { id = Arrival.Id }, Arrival);
        }

        // DELETE: api/Arrivals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrival(int id)
        {
            //Refactored
            //var Arrival = await _context.Arrivals.FindAsync(id);
            var Arrival = await _unitOfWork.Arrivals.Get(q => q.Id == id);
            if (Arrival == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Arrivals.Remove(Arrival);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Arrivals.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ArrivalExists(int id)
        private async Task<bool> ArrivalExists(int id)
        {
            //Refactored
            //return _context.Arrivals.Any(e => e.Id == id);
            var Arrival = await _unitOfWork.Arrivals.Get(q => q.Id == id);
            return Arrival != null;
        }
    }
}
