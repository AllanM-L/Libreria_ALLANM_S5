using LibreriaAPI.DTOs;

namespace LibreriaAPI.Interfaces
{
    public interface ITipoLibroService
    {
        Task<IEnumerable<TipoLibroDTO>> GetAll();
        Task<TipoLibroDTO?> GetById(int id);
        Task<TipoLibroDTO> Create(TipoLibroDTO tipoDto);
        Task<bool> Update(int id, TipoLibroDTO tipoDto);
        Task<bool> Delete(int id);
    }
}

