using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Services.Interfaces
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> GetUsuariosAsync();
        Task<Usuarios> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(Usuarios usuario);
        Task UpdateUsuarioAsync(Usuarios usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
