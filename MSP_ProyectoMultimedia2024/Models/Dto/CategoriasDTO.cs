using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSP_ProyectoMultimedia2024.Models.Dto
{

    public class CategoriasDTO
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [Column("nombre")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        // Relaciones con otras tablas
        public virtual ICollection<Cursos> Curso { get; set; } = new List<Cursos>();
    }


}
