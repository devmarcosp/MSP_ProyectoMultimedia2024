using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services;
using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.DTOs;

namespace MSP_ProyectoMultimedia2024.Services.Repository
{
    public class CursosRepository : ICursos
    {
        private readonly CleverlandContext _context;

        public CursosRepository(CleverlandContext context)
        {
            _context = context;
        }

        public async Task<List<Cursos>> GetCursosAsync()
        {
            return await _context.Cursos.Include(c => c.Instructor).ToListAsync();
        }

        public async Task<Cursos> GetDetailsAsync(int? id)
        {
            return await _context.Cursos.Include(c => c.Instructor).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<CursosDTO> GetEditAsync(int? id)
        {
            var curso = await _context.Cursos.Include(c => c.Instructor).FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return null;
            }

            return new CursosDTO
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descripcion = curso.Descripcion,
                InstructorId = curso.InstructorId,
                FechaCreacion = curso.FechaCreacion
            };
        }

        public async Task AddCursoAsync(CursosDTO cursoDto)
        {
            var cursoOriginal = cursoDto.ToOriginal();
            _context.Cursos.Add(cursoOriginal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCursoAsync(CursosDTO cursoDto)
        {
            var cursoOriginal = cursoDto.ToOriginal();
            _context.Cursos.Update(cursoOriginal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCursoAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CursosExistsAsync(int id)
        {
            return await _context.Cursos.AnyAsync(e => e.Id == id);
        }

        Task ICursos.AddCursoAsync(Cursos curso)
        {
            throw new NotImplementedException();
        }

        Task ICursos.UpdateCursoAsync(Cursos curso)
        {
            throw new NotImplementedException();
        }
    }
}
