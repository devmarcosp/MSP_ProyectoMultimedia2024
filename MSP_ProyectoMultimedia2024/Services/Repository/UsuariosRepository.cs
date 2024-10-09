using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;


public class UsuariosRepository : IUsuarios
{
    private readonly CleverlandContext _context;

    public UsuariosRepository(CleverlandContext context)
    {
        _context = context;
    }

    public async Task<List<Usuarios>> GetUsuariosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuarios> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddUsuarioAsync(Usuarios usuario) 
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUsuarioAsync(Usuarios usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    Task<List<Usuarios>> IUsuarios.GetUsuariosAsync()
    {
        
        return  _context.Usuarios.ToListAsync();
        

    }


    Task IUsuarios.AddUsuarioAsync(UsuariosDTO usuarioDto)
    {
        throw new NotImplementedException();
    }

    Task IUsuarios.UpdateUsuarioAsync(UsuariosDTO usuarioDto)
    {
        throw new NotImplementedException();
    }

    Task IUsuarios.DeleteUsuarioAsync(int id)
    {
        throw new NotImplementedException();
    }
}
