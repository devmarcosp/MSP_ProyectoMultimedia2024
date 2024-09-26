using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;


namespace MSP_ProyectoMultimedia2024.Services.Repository
{
    public class CursosRepository : ICursos
    {
        private readonly CleverlandContext _context;

        public CursosRepository(CleverlandContext context)
        {
            _context = context;
        }

        // Obtener todos los cursos
        public async Task<List<Cursos>> GetCursosAsync()
        {
            return await _context.Cursos
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        // Obtener detalles de un curso por id
        public async Task<Cursos> GetDetailsAsync(int? id)
        {
            return await _context.Cursos
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // Agregar un curso
        public async Task AddCursoAsync(Cursos curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        // Actualizar un curso
        public async Task UpdateCursoAsync(Cursos curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        // Eliminar un curso por id
        public async Task DeleteCursoAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }

        // Verificar si un curso existe por id
        public async Task<bool> CursosExistsAsync(int id)
        {
            return await _context.Cursos.AnyAsync(e => e.Id == id);
        }

        
    }
}
