using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

public partial class Registro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Column("curso_id")]
    public int CursoId { get; set; }

    [Column("fecha_inscripcion", TypeName = "datetime")]
    public DateTime? FechaInscripcion { get; set; }

    [ForeignKey("CursoId")]
    [InverseProperty("Registro")]
    public virtual Cursos Curso { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Registro")]
    public virtual Usuarios Usuario { get; set; } = null!;
}
