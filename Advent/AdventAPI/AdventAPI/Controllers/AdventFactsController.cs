using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventAPI.Model;
using AdventAPI.Models;

namespace AdventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventFactsController : ControllerBase
    {
        private readonly AdventContext _context;

        public AdventFactsController(AdventContext context)
        {
            _context = context;
        }

        // GET: api/AdventFacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdventFact>>> GetAdventFact()
        {
            return await _context.AdventFact.ToListAsync();
        }

        // GET: api/AdventFacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdventFact>> GetAdventFact(int id)
        {
            var adventFact = await _context.AdventFact.Where(f=> f.Day == id).FirstOrDefaultAsync();

            if (adventFact == null)
            {
                return NotFound();
            }

            return adventFact;
        }

        // PUT: api/AdventFacts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdventFact(int id, AdventFact adventFact)
        {
            if (id != adventFact.id)
            {
                return BadRequest();
            }

            _context.Entry(adventFact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdventFactExists(id))
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

        // POST: api/AdventFacts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdventFact>> PostAdventFact(AdventFact adventFact)
        {
            if (!await _context.AdventFact.Where(f => f.Day == adventFact.Day).AnyAsync())
            {
                _context.AdventFact.Add(adventFact);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAdventFact", new { id = adventFact.id }, adventFact);
            }
            else
            {
                return BadRequest();
            }
            
        }

        // DELETE: api/AdventFacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdventFact>> DeleteAdventFact(int id)
        {
            var adventFact = await _context.AdventFact.Where(f => f.Day == id).FirstOrDefaultAsync();
            if (adventFact == null)
            {
                return NotFound();
            }

            _context.AdventFact.Remove(adventFact);
            await _context.SaveChangesAsync();

            return adventFact;
        }

        private bool AdventFactExists(int id)
        {
            return _context.AdventFact.Any(e => e.id == id);
        }
    }
}
