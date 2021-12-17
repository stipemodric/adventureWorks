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
    [Route("api/grad")]
    [ApiController]
    public class GradController : ControllerBase
    {
        private readonly AdventureWorksOBPContext _context;
        private GradRepository _gradRepo;

        //public GradController(AdventureWorksOBPContext context)
        //{
        //    _context = context;
        //}

        public GradController(GradRepository gradRepo)
        {
            _gradRepo = gradRepo;
        }

        [HttpGet]
        [Route("get-by-drzava")]
        public async Task<ActionResult<ICollection<Grad>>> GetGradoviByDrzava(int? drzavaId)
        {
            try
            {
                var result = await _gradRepo.GetGradoviByDrzava(drzavaId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Grad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grad>>> GetGrads()
        {
            return await _context.Grads.ToListAsync();
        }

        // GET: api/Grad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grad>> GetGrad(int id)
        {
            var grad = await _context.Grads.FindAsync(id);

            if (grad == null)
            {
                return NotFound();
            }

            return grad;
        }

        // PUT: api/Grad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrad(int id, Grad grad)
        {
            if (id != grad.Idgrad)
            {
                return BadRequest();
            }

            _context.Entry(grad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradExists(id))
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

        // POST: api/Grad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Grad>> PostGrad(Grad grad)
        {
            _context.Grads.Add(grad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrad", new { id = grad.Idgrad }, grad);
        }

        // DELETE: api/Grad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grad>> DeleteGrad(int id)
        {
            var grad = await _context.Grads.FindAsync(id);
            if (grad == null)
            {
                return NotFound();
            }

            _context.Grads.Remove(grad);
            await _context.SaveChangesAsync();

            return grad;
        }

        private bool GradExists(int id)
        {
            return _context.Grads.Any(e => e.Idgrad == id);
        }
    }
}
