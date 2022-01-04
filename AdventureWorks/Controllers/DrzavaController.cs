using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;
using AdventureWorks.DataAccess.Repositories;
using AdventureWorks.Core.ViewModels.Drzava;

namespace AdventureWorks.Controllers
{
    [Route("api/drzava")]
    [ApiController]
    public class DrzavaController : ControllerBase
    {
        private readonly AdventureWorksOBPContext _context;
        private AuxiliaryRepository<DrzavaAddViewModel, Drzava> _auxRepo;
        public DrzavaController(AuxiliaryRepository<DrzavaAddViewModel, Drzava> auxRepo)
        {
            _auxRepo = auxRepo;
        }

        // GET: api/Drzavas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drzava>>> GetDrzavas()
        {
            return await _context.Drzavas.ToListAsync();
        }

        // GET: api/Drzavas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drzava>> GetDrzava(int id)
        {
            var drzava = await _context.Drzavas.FindAsync(id);

            if (drzava == null)
            {
                return NotFound();
            }

            return drzava;
        }

        // PUT: api/Drzavas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrzava(int id, Drzava drzava)
        {
            if (id != drzava.Iddrzava)
            {
                return BadRequest();
            }

            _context.Entry(drzava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzavaExists(id))
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

        // POST: api/Drzavas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<int> PostDrzava(DrzavaAddViewModel drzava)
        {
            //_context.Drzavas.Add(drzava);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDrzava", new { id = drzava.Iddrzava }, drzava);

            try
            {
                return await _auxRepo.Post(drzava);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Drzavas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drzava>> DeleteDrzava(int id)
        {
            var drzava = await _context.Drzavas.FindAsync(id);
            if (drzava == null)
            {
                return NotFound();
            }

            _context.Drzavas.Remove(drzava);
            await _context.SaveChangesAsync();

            return drzava;
        }

        private bool DrzavaExists(int id)
        {
            return _context.Drzavas.Any(e => e.Iddrzava == id);
        }
    }
}
