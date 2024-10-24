using System.Collections.Generic;
using System.Threading.Tasks;
using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Repositories
{
    public interface IClases
    {
        Task<IEnumerable<Clases>> GetAll();
        Task<Clases> GetById(int id);
        Task Create(Clases clase);
        Task Update(Clases clase);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
