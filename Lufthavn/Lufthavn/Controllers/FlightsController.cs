using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lufthavn.Models;
using System.Net;

namespace Lufthavn.Controllers
{
    public class FlightsController : Controller
    {
        private readonly LufthavnContext _context;

        public FlightsController(LufthavnContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index(string toString, string fromString)
        {
            var flights = from f in _context.Flight
                          select f;

            if (!string.IsNullOrEmpty(toString))
            {
                flights = flights.Where(f => f.ToLocation.Contains(toString));
            }

            if (!string.IsNullOrEmpty(fromString))
            {
                flights = flights.Where(f => f.FromLocation.Contains(fromString));
            }

            FlightSearchViewModel model = new FlightSearchViewModel
            {
                Flights = await flights.ToListAsync()
            };

            Response.StatusCode = (int) HttpStatusCode.OK;
            return View(model);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,AircraftType,FromLocation,ToLocation,DepartureTime,ArrivalTime")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,AircraftType,FromLocation,ToLocation,DepartureTime,ArrivalTime")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightId == id);
        }
    }
}
