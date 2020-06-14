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
    public class MedicosEspecialidadesController : ControllerBase
    {
        private readonly CLINICA_CITASContext _context;

        public MedicosEspecialidadesController(CLINICA_CITASContext context)
        {
            _context = context;
        }

        // GET: api/MedicosEspecialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosEspecialidades>>> GetMedicosEspecialidades()
        {
            return await _context.MedicosEspecialidades.ToListAsync();
        }

        // GET: api/MedicosEspecialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicosEspecialidades>> GetMedicosEspecialidades(int id)
        {
            var medicosEspecialidades = await _context.MedicosEspecialidades.FindAsync(id);

            if (medicosEspecialidades == null)
            {
                return NotFound();
            }

            return medicosEspecialidades;
        }

        // PUT: api/MedicosEspecialidades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicosEspecialidades(int id, MedicosEspecialidades medicosEspecialidades)
        {
            if (id != medicosEspecialidades.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicosEspecialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosEspecialidadesExists(id))
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

        // POST: api/MedicosEspecialidades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicosEspecialidades>> PostMedicosEspecialidades(MedicosEspecialidades medicosEspecialidades)
        {
            _context.MedicosEspecialidades.Add(medicosEspecialidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicosEspecialidades", new { id = medicosEspecialidades.Id }, medicosEspecialidades);
        }

        // DELETE: api/MedicosEspecialidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicosEspecialidades>> DeleteMedicosEspecialidades(int id)
        {
            var medicosEspecialidades = await _context.MedicosEspecialidades.FindAsync(id);
            if (medicosEspecialidades == null)
            {
                return NotFound();
            }

            _context.MedicosEspecialidades.Remove(medicosEspecialidades);
            await _context.SaveChangesAsync();

            return medicosEspecialidades;
        }

        private bool MedicosEspecialidadesExists(int id)
        {
            return _context.MedicosEspecialidades.Any(e => e.Id == id);
        }
    }
}
