using MSP_ProyectoMultimedia2024.Models.Dto;

public interface ICategorias
{
    Task<List<CategoriasDTO>> GetAllAsync();
    Task<CategoriasDTO> GetDetailsAsync(int? id);
    Task<CategoriasDTO> GetDeleteAsync(int? id);
    Task<CategoriasDTO> GetEditAsync(int? id);
    Task AddAsync(CategoriasDTO categoriaDto);
    Task UpdateAsync(CategoriasDTO categoriaDto);
    Task DeleteConfirmedAsync(int id);
    bool CategoriasExists(int id);
}
