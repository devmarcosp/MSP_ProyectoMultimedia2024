using System.Collections.Generic;
using System.Threading.Tasks;
using MSP_ProyectoMultimedia2024.Repositories;
using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Repositories
{
    public interface ICategoriaCurso
    {
        Task<IEnumerable<CategoriaCurso>> GetAll();
        Task<CategoriaCurso> GetById(int id);
        Task Create(CategoriaCurso categoriaCurso);
        Task Update(CategoriaCurso categoriaCurso);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
