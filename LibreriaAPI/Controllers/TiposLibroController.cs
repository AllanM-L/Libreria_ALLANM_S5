using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.Models;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposLibroController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public TiposLibroController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: api/tiposlibro
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipos = await _context.TipoLibros.ToListAsync();
            return Ok(tipos);
        }

        // GET: api/tiposlibro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _context.TipoLibros.FindAsync(id);

            if (tipo == null)
                return NotFound(new { message = "Tipo de libro no encontrado" });

            return Ok(tipo);
        }

        // POST: api/tiposlibro
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoLibro tipo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.TipoLibros.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tipo.IdTipo }, tipo);
        }

        // PUT: api/tiposlibro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoLibro tipo)
        {
            if (id != tipo.IdTipo)
                return BadRequest(new { message = "ID no coincide" });

            var tipoExistente = await _context.TipoLibros.FindAsync(id);
            if (tipoExistente == null)
                return NotFound(new { message = "Tipo no encontrado" });

            tipoExistente.NombreTipo = tipo.NombreTipo;
            tipoExistente.Descripcion = tipo.Descripcion;

            await _context.SaveChangesAsync();

            return Ok(tipoExistente);
        }

        // DELETE: api/tiposlibro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _context.TipoLibros.FindAsync(id);

            if (tipo == null)
                return NotFound(new { message = "Tipo no encontrado" });

            _context.TipoLibros.Remove(tipo);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tipo eliminado correctamente" });
        }
    }
}
