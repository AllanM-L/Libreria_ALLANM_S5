using Microsoft.AspNetCore.Mvc;
using LibreriaAPI.Interfaces;
using LibreriaAPI.Models;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var libros = await _libroService.GetAll();
            return Ok(libros);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            var nuevo = await _libroService.Create(libro);
            return Ok(nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libro libro)
        {
            var updated = await _libroService.Update(id, libro);
            if (!updated)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _libroService.Delete(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
