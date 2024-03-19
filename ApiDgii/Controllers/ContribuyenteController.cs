using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDgii.Models;

namespace ApiDgii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
       private readonly DbdgiiContext _context;

        public ContribuyenteController(DbdgiiContext context)
        {
            _context = context;
        }

        // GET: api/Contribuyente
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Contribuyente>>> GetContribuyentes()
        {
            return await _context.Contribuyentes.ToListAsync();
        }



        // GET: api/Contribuyente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuyente>> GetContribuyentes(string id)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(id);

            if (contribuyente == null)
            {
                return NotFound();
            }

            return contribuyente;
        }

        // POST: api/Contribuyente
        [HttpPost]
        public async Task<ActionResult<Contribuyente>> PostContribuyente(Contribuyente contribuyente)
        {
            _context.Contribuyentes.Add(contribuyente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContribuyentes), new { id = contribuyente.RncCedula }, contribuyente);
        }



        // PUT: api/Contribuyente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribuyente(string id, Contribuyente contribuyente)
        {
            if (id != contribuyente.RncCedula)
            {
                return BadRequest();
            }

            _context.Entry(contribuyente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContribuyenteExists(id))
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

        // DELETE: api/Contribuyente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribuyente(string id)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(id);
            if (contribuyente == null)
            {
                return NotFound();
            }

            _context.Contribuyentes.Remove(contribuyente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContribuyenteExists(string id)
        {
            return _context.Contribuyentes.Any(e => e.RncCedula == id);
        }

    }
}
