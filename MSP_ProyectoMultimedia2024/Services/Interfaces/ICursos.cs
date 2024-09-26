using MSP_ProyectoMultimedia2024.Models.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSP_ProyectoMultimedia2024.Services.Interfaces
{
    public interface ICursos
    {
        Task<List<Cursos>> GetCursosAsync();
        Task<Cursos> GetDetailsAsync(int? id);
        Task AddCursoAsync(Cursos curso);
        Task UpdateCursoAsync(Cursos curso);
        Task DeleteCursoAsync(int id);
        Task<bool> CursosExistsAsync(int id);
    }
}
