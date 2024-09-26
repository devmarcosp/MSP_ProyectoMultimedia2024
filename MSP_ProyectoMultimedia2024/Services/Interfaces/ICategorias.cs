using MSP_ProyectoMultimedia2024.Models.Tables;


namespace MSP_ProyectoMultimedia2024.Services.Interfaces
{
    public interface ICategorias
    {
        Task<List<Categorias>> GetAllAsync();
        Task<Categorias> GetDetailsAsync(int? id);
        Task AddAsync(Categorias categorias);
        Task<Categorias> GetEditAsync(int? id);
        Task UpdateAsync(Categorias categorias);
        Task<Categorias> GetDeleteAsync(int? id);
        Task DeleteConfirmedAsync(int id);
        bool CategoriasExists(int id);
    }

}