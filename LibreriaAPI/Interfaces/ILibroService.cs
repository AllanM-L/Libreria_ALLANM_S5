using LibreriaAPI.DTOs;
using LibreriaAPI.Models;

namespace LibreriaAPI.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<LibroDTO>> GetAll();
        Task<Libro?> GetById(int id);
        Task<Libro> Create(Libro libro);
        Task<bool> Update(int id, Libro libro);
        Task<bool> Delete(int id);
    }
}
