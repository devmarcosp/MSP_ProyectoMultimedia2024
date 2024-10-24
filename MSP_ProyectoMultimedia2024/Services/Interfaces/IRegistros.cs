using MSP_ProyectoMultimedia2024.Models.Tables;
using System.Collections;

public interface IRegistros
{
    Task<IEnumerable<Registro>> GetAllAsync();
    Task<Registro> GetByIdAsync(int id);
    Task AddAsync(Registro registro);
    Task UpdateAsync(Registro registro);
    Task DeleteAsync(int id);
    bool RegistroExists(int id);
    IEnumerable <Cursos>GetCursos();
    IEnumerable <Usuarios>GetUsuarios();
}
