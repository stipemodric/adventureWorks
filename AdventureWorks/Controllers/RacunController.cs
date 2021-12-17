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
    public class RacunController : ControllerBase
    {
        private readonly AdventureWorksOBPContext _context;
        private RacunRepository _racunRepo;

        public RacunController(RacunRepository racunRepo)
        {
            _racunRepo = racunRepo;
        }

        [HttpGet]
        [Route("get-by-kupac/{kupacId:int}")]
        public async Task<ICollection<Racun>> GetRacunDetailsByKupac(int kupacId, int? sortId)
        {
            try
            {
                return await _racunRepo.GetRacunDetailsByKupac(kupacId, sortId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Racun
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Racun>>> GetRacuns()
        {
            return await _context.Racuns.ToListAsync();
        }

        // GET: api/Racun/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Racun>> GetRacun(int id)
        {
            var racun = await _context.Racuns.FindAsync(id);

            if (racun == null)
            {
                return NotFound();
            }

            return racun;
        }

        // PUT: api/Racun/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacun(int id, Racun racun)
        {
            if (id != racun.Idracun)
            {
                return BadRequest();
            }

            _context.Entry(racun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunExists(id))
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

        // POST: api/Racun
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Racun>> PostRacun(Racun racun)
        {
            _context.Racuns.Add(racun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRacun", new { id = racun.Idracun }, racun);
        }

        // DELETE: api/Racun/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Racun>> DeleteRacun(int id)
        {
            var racun = await _context.Racuns.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            _context.Racuns.Remove(racun);
            await _context.SaveChangesAsync();

            return racun;
        }

        private bool RacunExists(int id)
        {
            return _context.Racuns.Any(e => e.Idracun == id);
        }
    }
}
