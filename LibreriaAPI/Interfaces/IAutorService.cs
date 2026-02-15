using LibreriaAPI.DTOs;

namespace LibreriaAPI.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorDTO>> GetAll();
        Task<AutorDTO?> GetById(int id);
        Task<AutorDTO> Create(AutorDTO autorDto);
        Task<bool> Update(int id, AutorDTO autorDto);
        Task<bool> Delete(int id);
    }
}
