using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

public partial class Clases
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("contenido", TypeName = "text")]
    public string? Contenido { get; set; }

    [Column("url_video")]
    [StringLength(255)]
    [Unicode(false)]
    public string? UrlVideo { get; set; }

    [Column("curso_id")]
    public int CursoId { get; set; }

    [Column("orden")]
    public int? Orden { get; set; }

    [ForeignKey("CursoId")]
    [InverseProperty("Clases")]
    public virtual Cursos Curso { get; set; } = null!;
}
