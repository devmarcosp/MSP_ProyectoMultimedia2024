using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Repositories;


namespace MSP_ProyectoMultimedia2024.Repositories
    {
        public class CategoriaCursoRepository : ICategoriaCurso
        {
            private readonly CleverlandContext _context;

            public CategoriaCursoRepository(CleverlandContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CategoriaCurso>> GetAll()
            {
                return await _context.CategoriaCurso.Include(c => c.Categoria).Include(c => c.Curso).ToListAsync();
            }

            public async Task<CategoriaCurso> GetById(int id)
            {
                return await _context.CategoriaCurso.Include(c => c.Categoria).Include(c => c.Curso).FirstOrDefaultAsync(c => c.CursoId == id);
            }

            public async Task Create(CategoriaCurso categoriaCurso)
            {
                _context.Add(categoriaCurso);
                await _context.SaveChangesAsync();
            }

            public async Task Update(CategoriaCurso categoriaCurso)
            {
                _context.Update(categoriaCurso);
                await _context.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
                var categoriaCurso = await _context.CategoriaCurso.FindAsync(id);
                if (categoriaCurso != null)
                {
                    _context.CategoriaCurso.Remove(categoriaCurso);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> Exists(int id)
            {
                return await _context.CategoriaCurso.AnyAsync(e => e.CursoId == id);
            }
        }
    }

