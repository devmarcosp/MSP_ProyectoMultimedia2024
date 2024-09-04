using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

public partial class Categorias
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("CategoriaId")]
    [InverseProperty("Categoria")]
    public virtual ICollection<Cursos> Curso { get; set; } = new List<Cursos>();
}
