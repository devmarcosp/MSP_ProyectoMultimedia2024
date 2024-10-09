using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSP_ProyectoMultimedia2024.Models.Dto
{
    public class CursosDTO
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Título es obligatorio.")]
    [Column("titulo")]
    [StringLength(255, ErrorMessage = "El título no puede exceder los 255 caracteres.")]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [Column("descripcion", TypeName = "text")]
    public string Descripcion { get; set; } = null!;

    [Required(ErrorMessage = "El campo InstructorId es obligatorio.")]
    [Column("instructor_id")]
    public int InstructorId { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Clases> Clases { get; set; } = new List<Clases>();
    public virtual Usuarios Instructor { get; set; } = null!;
    public virtual ICollection<Registro> Registro { get; set; } = new List<Registro>();
    public virtual ICollection<Categorias> Categoria { get; set; } = new List<Categorias>();
}


}
