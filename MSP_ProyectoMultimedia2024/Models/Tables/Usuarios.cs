﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Tables;

[Index("Email", Name = "UQ__Usuarios__AB6E61642BE133B1", IsUnique = true)]
public partial class Usuarios
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(100)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [Column("email")]
    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("tipo_usuario")]
    [StringLength(10)]
    [Unicode(false)]
    public string TipoUsuario { get; set; } = null!;

    [Column("fecha_registro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [InverseProperty("Instructor")]
    public virtual ICollection<Cursos> Cursos { get; set; } = new List<Cursos>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Registro> Registro { get; set; } = new List<Registro>();
}