using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

[PrimaryKey("CursoId", "CategoriaId")]
[Table("Categoria_Curso")]
public partial class CategoriaCurso
{
    [Key]
    [Column("curso_id")]
    public int CursoId { get; set; }

    [Key]
    [Column("categoria_id")]
    public int CategoriaId { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("CategoriaCurso")]
    public virtual Categorias Categoria { get; set; }

    [ForeignKey("CursoId")]
    [InverseProperty("CategoriaCurso")]
    public virtual Cursos Curso { get; set; }
}
