using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSP_ProyectoMultimedia2024.Models.Dto
{
    public class UsuariosDTO
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [Column("nombre")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [Column("apellido")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        [Unicode(false)]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [Column("email")]
        [StringLength(150, ErrorMessage = "El email no puede exceder los 150 caracteres.")]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [Column("password")]
        [StringLength(255, ErrorMessage = "La contraseña no puede exceder los 255 caracteres.")]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El campo Tipo de Usuario es obligatorio.")]
        [Column("tipo_usuario")]
        [StringLength(10, ErrorMessage = "El tipo de usuario no puede exceder los 10 caracteres.")]
        [Unicode(false)]
        public string TipoUsuario { get; set; } = null!;

        [Column("fecha_registro", TypeName = "datetime")]
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Cursos> Cursos { get; set; } = new List<Cursos>();
        public virtual ICollection<Registro> Registro { get; set; } = new List<Registro>();
    }

}
