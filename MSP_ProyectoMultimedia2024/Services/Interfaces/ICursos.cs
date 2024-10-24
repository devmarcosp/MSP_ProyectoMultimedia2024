using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICursos
{
    Task<List<Cursos>> GetCursosAsync();
    Task<Cursos> GetDetailsAsync(int? id);
    Task<CursosDTO> GetEditAsync(int? id);
    Task AddCursoAsync(CursosDTO cursoDto);
    Task UpdateCursoAsync(CursosDTO cursoDto);
    Task DeleteCursoAsync(int id);
    Task<bool> CursosExistsAsync(int id);
}
