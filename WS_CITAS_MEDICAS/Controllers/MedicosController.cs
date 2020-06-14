using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WS_CITAS_MEDICAS.Models;

namespace WS_CITAS_MEDICAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly CLINICA_CITASContext _context;

        public MedicosController(CLINICA_CITASContext context)
        {
            _context = context;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicos>>> GetMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicos>> GetMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos;
        }

        // PUT: api/Medicos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(int id, Medicos medicos)
        {
            if (id != medicos.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
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

        // POST: api/Medicos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medicos>> PostMedicos(Medicos medicos)
        {
            _context.Medicos.Add(medicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicos", new { id = medicos.Id }, medicos);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicos>> DeleteMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return medicos;
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
