using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Models.DTOs
{
    public static class DTOTransformation
    {
        // Usuarios
        public static Usuarios ToOriginal(this UsuariosDTO dto)
        {
            return new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Password = dto.Password,
                TipoUsuario = dto.TipoUsuario,
                FechaRegistro = dto.FechaRegistro
            };
        }

        public static UsuariosDTO ToDto(this Usuarios original)
        {
            return new()
            {
                
            };
        }

        // Categorias
        public static Categorias ToOriginal(this CategoriasDTO dto)
        {
            return new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public static CategoriasDTO ToDto(this Categorias original)
        {
            return new()
            {
                
            };
        }

        // Cursos
        public static Cursos ToOriginal(this CursosDTO dto)
        {
            return new()
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                InstructorId = dto.InstructorId,
               
            };
        }

        public static CursosDTO ToDto(this Cursos original)
        {
            return new()
            {
           
            };
        }

  
  


    }
}
