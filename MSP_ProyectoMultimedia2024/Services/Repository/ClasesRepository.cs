using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Repositories
{
    public class ClasesRepository : IClases
    {
        private readonly CleverlandContext _context;

        public ClasesRepository(CleverlandContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clases>> GetAll()
        {
            return await _context.Clases.Include(c => c.Curso).ToListAsync();
        }



        public async Task<Clases> GetById(int id)
        {
            return await _context.Clases.Include(c => c.Curso).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Clases clase)
        {
            _context.Clases.Add(clase);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Clases clase)
        {
            _context.Clases.Update(clase);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Clases.AnyAsync(e => e.Id == id);
        }
    }
}
