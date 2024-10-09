using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;

public interface IUsuarios
{
    Task<List<Usuarios>> GetUsuariosAsync();
    Task<Usuarios> GetUsuarioByIdAsync(int id);
    Task AddUsuarioAsync(UsuariosDTO usuarioDto);
    Task UpdateUsuarioAsync(UsuariosDTO usuarioDto); 
    Task DeleteUsuarioAsync(int id);
    Task UpdateUsuarioAsync(Usuarios usuario);
    Task AddUsuarioAsync(Usuarios usuario);
}
