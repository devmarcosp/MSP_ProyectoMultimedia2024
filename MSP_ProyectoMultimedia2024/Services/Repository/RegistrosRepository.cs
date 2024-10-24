using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


public class RegistrosRepository : IRegistros
{
    private readonly CleverlandContext _context;

    public RegistrosRepository(CleverlandContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Registro>> GetAllAsync()
    {
        return await _context.Registro
            .Include(r => r.Curso)
            .Include(r => r.Usuario)
            .ToListAsync();
    }

    public async Task<Registro> GetByIdAsync(int id)
    {
        return await _context.Registro
            .Include(r => r.Curso)
            .Include(r => r.Usuario)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Registro registro)
    {
        await _context.Registro.AddAsync(registro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Registro registro)
    {
        _context.Registro.Update(registro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var registro = await _context.Registro.FindAsync(id);
        if (registro != null)
        {
            _context.Registro.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }

    public bool RegistroExists(int id)
    {
        return _context.Registro.Any(e => e.Id == id);
    }

    public IEnumerable<Cursos> GetCursos()
    {
        return _context.Cursos.ToList();
    }

    public IEnumerable<Usuarios> GetUsuarios()
    {
        return _context.Usuarios.ToList();
    }
}
