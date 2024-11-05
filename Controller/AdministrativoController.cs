using Microsoft.AspNetCore.Mvc;
using CrudApi.Data;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrativoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministrativoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Administrativo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrativo>>> GetAdministrativos()
        {
            return await _context.Administrativos.Include(a => a.Colaborador).ToListAsync();
        }

        // GET: api/Administrativo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrativo>> GetAdministrativo(int id)
        {
            var administrativo = await _context.Administrativos.Include(a => a.Colaborador).FirstOrDefaultAsync(a => a.Id == id);

            if (administrativo == null)
            {
                return NotFound();
            }

            return administrativo;
        }

        // POST: api/Administrativo
        [HttpPost]
        public async Task<ActionResult<Administrativo>> PostAdministrativo(Administrativo administrativo)
        {
            _context.Administrativos.Add(administrativo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdministrativo), new { id = administrativo.Id }, administrativo);
        }

        // PUT: api/Administrativo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrativo(int id, Administrativo administrativo)
        {
            if (id != administrativo.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrativoExists(id))
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

        // DELETE: api/Administrativo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrativo(int id)
        {
            var administrativo = await _context.Administrativos.FindAsync(id);
            if (administrativo == null)
            {
                return NotFound();
            }

            _context.Administrativos.Remove(administrativo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministrativoExists(int id)
        {
            return _context.Administrativos.Any(e => e.Id == id);
        }
    }
}
