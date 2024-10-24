using MSP_ProyectoMultimedia2024.Models.Tables;

public interface IInstructores
{
    Task<IEnumerable<Instructores>> GetAllAsync();
    Task<Instructores> GetByIdAsync(int? id);
    Task AddAsync(Instructores instructor);
    Task UpdateAsync(Instructores instructor);
    Task DeleteAsync(int id);
    bool InstructorExists(int id);
}
