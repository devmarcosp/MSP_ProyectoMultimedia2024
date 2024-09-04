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
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F95761BE5");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Clases>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clases__3213E83FDA28ECFF");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Curso).WithMany(p => p.Clases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clases__curso_id__571DF1D5");
        });

        modelBuilder.Entity<Cursos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3213E83F0959C95E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Cursos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cursos__instruct__4E88ABD4");

            entity.HasMany(d => d.Categoria).WithMany(p => p.Curso)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriaCurso",
                    r => r.HasOne<Categorias>().WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__categ__5441852A"),
                    l => l.HasOne<Cursos>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__curso__534D60F1"),
                    j =>
                    {
                        j.HasKey("CursoId", "CategoriaId").HasName("PK__Categori__B0C34884AE119D25");
                        j.ToTable("Categoria_Curso");
                        j.IndexerProperty<int>("CursoId").HasColumnName("curso_id");
                        j.IndexerProperty<int>("CategoriaId").HasColumnName("categoria_id");
                    });
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3213E83FF58BECDD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Curso).WithMany(p => p.Registro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__curso___5BE2A6F2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Registro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__usuari__5AEE82B9");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83F3BC91BA1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
