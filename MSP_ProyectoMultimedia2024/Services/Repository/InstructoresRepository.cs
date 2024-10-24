using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;

public class InstructoresRepository : IInstructores
{
    private readonly CleverlandContext _context;

    public InstructoresRepository(CleverlandContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Instructores>> GetAllAsync()
    {
        return await _context.Instructores.ToListAsync();
    }

    public async Task<Instructores> GetByIdAsync(int? id)
    {
        return await _context.Instructores.FirstOrDefaultAsync(m => m.IdInstructor == id);
    }

    public async Task AddAsync(Instructores instructor)
    {
        await _context.Instructores.AddAsync(instructor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Instructores instructor)
    {
        _context.Instructores.Update(instructor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var instructor = await _context.Instructores.FindAsync(id);
        if (instructor != null)
        {
            _context.Instructores.Remove(instructor);
            await _context.SaveChangesAsync();
        }
    }

    public bool InstructorExists(int id)
    {
        return _context.Instructores.Any(e => e.IdInstructor == id);
    }
}
