using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Student.Data;
using University_Student.Models;

namespace University_Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class scholarsController : ControllerBase
    {
        private readonly University_StudentContext _context;

        public scholarsController(University_StudentContext context)
        {
            _context = context;
        }

        // GET: api/scholars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<scholar>>> Getscholar()
        {
            return await _context.scholar.ToListAsync();
        }

        // GET: api/scholars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<scholar>> Getscholar(int id)
        {
            var scholar = await _context.scholar.FindAsync(id);

            if (scholar == null)
            {
                return NotFound();
            }

            return scholar;
        }

        // PUT: api/scholars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putscholar(int id, scholar scholar)
        {
            if (id != scholar.Id)
            {
                return BadRequest();
            }

            _context.Entry(scholar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!scholarExists(id))
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

        // POST: api/scholars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<scholar>> Postscholar(scholar scholar)
        {
            _context.scholar.Add(scholar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getscholar", new { id = scholar.Id }, scholar);
        }

        // DELETE: api/scholars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<scholar>> Deletescholar(int id)
        {
            var scholar = await _context.scholar.FindAsync(id);
            if (scholar == null)
            {
                return NotFound();
            }

            _context.scholar.Remove(scholar);
            await _context.SaveChangesAsync();

            return scholar;
        }

        private bool scholarExists(int id)
        {
            return _context.scholar.Any(e => e.Id == id);
        }
    }
}
