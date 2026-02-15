using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.Interfaces;
using LibreriaAPI.Models;
using LibreriaAPI.DTOs;

namespace LibreriaAPI.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibreriaContext _context;

        public LibroService(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LibroDTO>> GetAll()
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.TipoLibro)
                .Select(l => new LibroDTO
                {
                    IdLibro = l.IdLibro,
                    Titulo = l.Titulo,
                    Precio = l.Precio,
                    Stock = l.Stock,
                    Autor = l.Autor!.Nombre,
                    TipoLibro = l.TipoLibro!.NombreTipo
                })
                .ToListAsync();
        }

        public async Task<Libro?> GetById(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<Libro> Create(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<bool> Update(int id, Libro libro)
        {
            if (id != libro.IdLibro)
                return false;

            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
                return false;

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

