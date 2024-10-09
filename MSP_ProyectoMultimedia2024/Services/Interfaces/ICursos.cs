using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;

public interface ICursos
{
    Task<List<Cursos>> GetCursosAsync();

    Task<CursosDTO> GetEditAsync(int? id);
    Task<Cursos> GetDetailsAsync(int? id);
    Task AddCursoAsync(CursosDTO cursoDto); 
    Task UpdateCursoAsync(CursosDTO cursoDto);
    Task DeleteCursoAsync(int id);
    Task<bool> CursosExistsAsync(int id);
    Task AddCursoAsync(Cursos curso);
    Task UpdateCursoAsync(Cursos curso);

}
