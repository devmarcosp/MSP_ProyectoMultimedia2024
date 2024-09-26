using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace MSP_ProyectoMultimedia2024.Services.Repository
{
    public class CategoriasRepository : ICategorias
    {
        private readonly CleverlandContext _context;

        public CategoriasRepository(CleverlandContext context)
        {
            _context = context;
        }

        // Obtener todas las categorías (Index)
        public async Task<List<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        // Obtener detalles de una categoría (Details)
        public async Task<Categorias> GetDetailsAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // Crear una categoría (Create)
        public async Task AddAsync(Categorias categorias)
        {
            _context.Add(categorias);
            await _context.SaveChangesAsync();
        }

        // Obtener una categoría para editar (GET Edit)
        public async Task<Categorias> GetEditAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Categorias.FindAsync(id);
        }

        // Actualizar una categoría (POST Edit)
        public async Task UpdateAsync(Categorias categorias)
        {
            _context.Update(categorias);
            await _context.SaveChangesAsync();
        }

        // Obtener una categoría para eliminar (GET Delete)
        public async Task<Categorias> GetDeleteAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // Confirmar eliminación de categoría (POST Delete)
        public async Task DeleteConfirmedAsync(int id)
        {
            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias != null)
            {
                _context.Categorias.Remove(categorias);
                await _context.SaveChangesAsync();
            }
        }

        // Comprobar si una categoría existe (CategoriasExists)
        public bool CategoriasExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }

}
