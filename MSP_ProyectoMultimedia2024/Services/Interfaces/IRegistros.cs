using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Services.Interfaces
{
    public interface IRegistros
    {
        Task<List<Registro>> GetRegistrosAsync();
        Task<Registro> GetRegistroByIdAsync(int id);
        Task AddRegistroAsync(Registro registro);
        Task UpdateRegistroAsync(Registro registro);
        Task DeleteRegistroAsync(int id);
    }
}
