using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.DTOs;
using LibreriaAPI.Interfaces;
using LibreriaAPI.Models;

namespace LibreriaAPI.Services
{
    public class TipoLibroService : ITipoLibroService
    {
        private readonly LibreriaContext _context;

        public TipoLibroService(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoLibroDTO>> GetAll()
        {
            return await _context.TipoLibros
                .Select(t => new TipoLibroDTO
                {
                    IdTipo = t.IdTipo,
                    NombreTipo = t.NombreTipo,
                    Descripcion = t.Descripcion
                })
                .ToListAsync();
        }

        public async Task<TipoLibroDTO?> GetById(int id)
        {
            var tipo = await _context.TipoLibros.FindAsync(id);

            if (tipo == null)
                return null;

            return new TipoLibroDTO
            {
                IdTipo = tipo.IdTipo,
                NombreTipo = tipo.NombreTipo,
                Descripcion = tipo.Descripcion
            };
        }

        public async Task<TipoLibroDTO> Create(TipoLibroDTO tipoDto)
        {
            var tipo = new TipoLibro
            {
                NombreTipo = tipoDto.NombreTipo,
                Descripcion = tipoDto.Descripcion
            };

            _context.TipoLibros.Add(tipo);
            await _context.SaveChangesAsync();

            tipoDto.IdTipo = tipo.IdTipo;
            return tipoDto;
        }

        public async Task<bool> Update(int id, TipoLibroDTO tipoDto)
        {
            var tipo = await _context.TipoLibros.FindAsync(id);
            if (tipo == null)
                return false;

            tipo.NombreTipo = tipoDto.NombreTipo;
            tipo.Descripcion = tipoDto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var tipo = await _context.TipoLibros.FindAsync(id);
            if (tipo == null)
                return false;

            _context.TipoLibros.Remove(tipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
