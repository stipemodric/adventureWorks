using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;
using AdventureWorks.DataAccess.Repositories;

namespace AdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        private readonly AdventureWorksOBPContext _context;
        private KupacRepository _kupacRepo;

        public KupacController(KupacRepository kupacRepo)
        {
            _kupacRepo = kupacRepo;
        }

        [HttpGet]
        [Route("get-by-grad/{gradId:int}")]
        public async Task<ActionResult<ICollection<Kupac>>> GetKupacsByGrad(int gradId)
        {
            try
            {
                var result = await _kupacRepo.GetKupacsByGrad(gradId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Kupac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kupac>>> GetKupacs()
        {
            return await _context.Kupacs.ToListAsync();
        }

        // GET: api/Kupac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kupac>> GetKupac(int id)
        {
            var kupac = await _context.Kupacs.FindAsync(id);

            if (kupac == null)
            {
                return NotFound();
            }

            return kupac;
        }

        // PUT: api/Kupac/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKupac(int id, Kupac kupac)
        {
            if (id != kupac.Idkupac)
            {
                return BadRequest();
            }

            _context.Entry(kupac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(id))
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

        // POST: api/Kupac
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kupac>> PostKupac(Kupac kupac)
        {
            _context.Kupacs.Add(kupac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKupac", new { id = kupac.Idkupac }, kupac);
        }

        // DELETE: api/Kupac/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kupac>> DeleteKupac(int id)
        {
            var kupac = await _context.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }

            _context.Kupacs.Remove(kupac);
            await _context.SaveChangesAsync();

            return kupac;
        }

        private bool KupacExists(int id)
        {
            return _context.Kupacs.Any(e => e.Idkupac == id);
        }
    }
}
