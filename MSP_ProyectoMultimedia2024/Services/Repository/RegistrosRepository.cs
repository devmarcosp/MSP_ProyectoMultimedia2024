using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;

namespace MSP_ProyectoMultimedia2024.Services.Repository
{
    public class RegistrosRepository : IRegistros
    {
        private readonly CleverlandContext _context;

        public RegistrosRepository(CleverlandContext context)
        {
            _context = context;
        }

        public async Task<List<Registro>> GetRegistrosAsync()
        {
            return await _context.Registro.Include(r => r.Curso).Include(r => r.Usuario).ToListAsync();
        }

        public async Task<Registro> GetRegistroByIdAsync(int id)
        {
            return await _context.Registro.Include(r => r.Curso).Include(r => r.Usuario).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRegistroAsync(Registro registro)
        {
            await _context.Registro.AddAsync(registro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRegistroAsync(Registro registro)
        {
            _context.Registro.Update(registro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRegistroAsync(int id)
        {
            var registro = await _context.Registro.FindAsync(id);
            if (registro != null)
            {
                _context.Registro.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
