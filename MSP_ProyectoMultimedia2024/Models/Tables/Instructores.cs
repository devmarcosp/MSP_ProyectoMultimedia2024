using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

[Index("Email", Name = "UQ__Instruct__AB6E6164602D36F3", IsUnique = true)]
public partial class Instructores
{
    [Key]
    [Column("id_instructor")]
    public int IdInstructor { get; set; }

    [Required]
    [Column("nombre_instructor")]
    [StringLength(255)]
    public string NombreInstructor { get; set; }

    [Column("especialidad")]
    [StringLength(255)]
    public string Especialidad { get; set; }

    [Required]
    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; }
}
