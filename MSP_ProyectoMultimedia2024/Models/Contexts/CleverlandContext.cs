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

    public virtual DbSet<CategoriaCurso> CategoriaCurso { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clases> Clases { get; set; }

    public virtual DbSet<Cursos> Cursos { get; set; }

    public virtual DbSet<Instructores> Instructores { get; set; }

    public virtual DbSet<Registro> Registro { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= MARCOS\\SQL2023; Database=CLEVERLAND;TrustServerCertificate=True;Trusted_Connection=True;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaCurso>(entity =>
        {
            entity.HasKey(e => new { e.CursoId, e.CategoriaId }).HasName("PK__Categori__B0C34884283604EA");

            entity.Property(e => e.CategoriaId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Categoria).WithMany(p => p.CategoriaCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Categoria__categ__6D0D32F4");

            entity.HasOne(d => d.Curso).WithMany(p => p.CategoriaCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Categoria__curso__6C190EBB");
        });

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
        });

        modelBuilder.Entity<Instructores>(entity =>
        {
            entity.HasKey(e => e.IdInstructor).HasName("PK__Instruct__1CCC4C1240208BF4");
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
