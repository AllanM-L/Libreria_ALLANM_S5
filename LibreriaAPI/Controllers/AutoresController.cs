using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.Models;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: api/autores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var autores = await _context.Autores.ToListAsync();
            return Ok(autores);
        }

        // GET: api/autores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return NotFound(new { message = "Autor no encontrado" });

            return Ok(autor);
        }

        // POST: api/autores
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = autor.IdAutor }, autor);
        }

        // PUT: api/autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.IdAutor)
                return BadRequest(new { message = "ID no coincide" });

            var autorExistente = await _context.Autores.FindAsync(id);
            if (autorExistente == null)
                return NotFound(new { message = "Autor no encontrado" });

            autorExistente.Nombre = autor.Nombre;
            autorExistente.Nacionalidad = autor.Nacionalidad;

            await _context.SaveChangesAsync();

            return Ok(autorExistente);
        }

        // DELETE: api/autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return NotFound(new { message = "Autor no encontrado" });

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Autor eliminado correctamente" });
        }
    }
}
