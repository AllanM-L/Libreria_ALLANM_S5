using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.DTOs;
using LibreriaAPI.Interfaces;
using LibreriaAPI.Models;

namespace LibreriaAPI.Services
{
    public class AutorService : IAutorService
    {
        private readonly LibreriaContext _context;

        public AutorService(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AutorDTO>> GetAll()
        {
            return await _context.Autores
                .Select(a => new AutorDTO
                {
                    IdAutor = a.IdAutor,
                    Nombre = a.Nombre,
                    Nacionalidad = a.Nacionalidad
                })
                .ToListAsync();
        }

        public async Task<AutorDTO?> GetById(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return null;

            return new AutorDTO
            {
                IdAutor = autor.IdAutor,
                Nombre = autor.Nombre,
                Nacionalidad = autor.Nacionalidad
            };
        }

        public async Task<AutorDTO> Create(AutorDTO autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Nacionalidad = autorDto.Nacionalidad
            };

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            autorDto.IdAutor = autor.IdAutor;
            return autorDto;
        }

        public async Task<bool> Update(int id, AutorDTO autorDto)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
                return false;

            autor.Nombre = autorDto.Nombre;
            autor.Nacionalidad = autorDto.Nacionalidad;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
                return false;

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

