using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

public partial class Cursos
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("descripcion", TypeName = "text")]
    public string Descripcion { get; set; } = null!;

    [Column("instructor_id")]
    public int InstructorId { get; set; }

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("Curso")]
    public virtual ICollection<Clases> Clases { get; set; } = new List<Clases>();

    [ForeignKey("InstructorId")]
    [InverseProperty("Cursos")]
    public virtual Usuarios Instructor { get; set; } = null!;

    [InverseProperty("Curso")]
    public virtual ICollection<Registro> Registro { get; set; } = new List<Registro>();

    [ForeignKey("CursoId")]
    [InverseProperty("Curso")]
    public virtual ICollection<Categorias> Categoria { get; set; } = new List<Categorias>();
}
