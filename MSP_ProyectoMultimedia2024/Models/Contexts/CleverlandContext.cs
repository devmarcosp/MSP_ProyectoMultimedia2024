using System;
using System.Collections.Generic;
using MSP_ProyectoMultimedia2024.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace MSP_ProyectoMultimedia2024.Models.Contexts;

public partial class CleverlandContext : DbContext
{
    public CleverlandContext()
    {
    }

    public CleverlandContext(DbContextOptions<CleverlandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clases> Clases { get; set; }

    public virtual DbSet<Cursos> Cursos { get; set; }

    public virtual DbSet<Registro> Registro { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F58F90B5D");
        });

        modelBuilder.Entity<Clases>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clases__3213E83FD10D45D1");

            entity.HasOne(d => d.Curso).WithMany(p => p.Clases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clases__curso_id__6FE99F9F");
        });

        modelBuilder.Entity<Cursos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3213E83F05A8497A");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Cursos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cursos__instruct__6754599E");

            entity.HasMany(d => d.Categoria).WithMany(p => p.Curso)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriaCurso",
                    r => r.HasOne<Categorias>().WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__categ__6D0D32F4"),
                    l => l.HasOne<Cursos>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__curso__6C190EBB"),
                    j =>
                    {
                        j.HasKey("CursoId", "CategoriaId").HasName("PK__Categori__B0C34884283604EA");
                        j.ToTable("Categoria_Curso");
                        j.IndexerProperty<int>("CursoId").HasColumnName("curso_id");
                        j.IndexerProperty<int>("CategoriaId")
                            .ValueGeneratedOnAdd()
                            .HasColumnName("categoria_id");
                    });
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3213E83FF4DCAF7E");

            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Curso).WithMany(p => p.Registro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__curso___74AE54BC");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Registro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__usuari__73BA3083");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83FAF583A36");

            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
