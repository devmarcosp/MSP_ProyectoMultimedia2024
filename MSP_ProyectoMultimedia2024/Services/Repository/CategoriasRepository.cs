using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSP_ProyectoMultimedia2024.Services.Repository
{
    public class CategoriasRepository : ICategorias
    {
        private readonly CleverlandContext _context;

        public CategoriasRepository(CleverlandContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriasDTO>> GetAllAsync()
        {
            return await _context.Categorias
                                 .Select(c => new CategoriasDTO
                                 {
                                     Id = c.Id,
                                     Nombre = c.Nombre
                                 })
                                 .ToListAsync();
        }

        public async Task<CategoriasDTO> GetDetailsAsync(int? id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return null;
            }

            return new CategoriasDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }

        public async Task<CategoriasDTO> GetEditAsync(int? id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return null;
            }

            return new CategoriasDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }

        public async Task<CategoriasDTO> GetDeleteAsync(int? id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return null;
            }

            return new CategoriasDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }

        public async Task AddAsync(CategoriasDTO categoriaDto)
        {
            var nuevaCategoria = new MSP_ProyectoMultimedia2024.Models.Tables.Categorias
            {
                Nombre = categoriaDto.Nombre
            };

            _context.Categorias.Add(nuevaCategoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoriasDTO categoriaDto)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(categoriaDto.Id);
            if (categoriaExistente == null)
            {
                throw new KeyNotFoundException("Categoría no encontrada.");
            }

            categoriaExistente.Nombre = categoriaDto.Nombre;

            _context.Categorias.Update(categoriaExistente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public bool CategoriasExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
