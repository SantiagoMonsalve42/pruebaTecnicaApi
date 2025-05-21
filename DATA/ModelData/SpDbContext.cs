using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData;

public partial class SpDbContext : DbContext
{
    public SpDbContext()
    {
    }

    public SpDbContext(DbContextOptions<SpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteMateria> EstudianteMaterias { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<ProfesorMateria> ProfesorMaterias { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__Estudian__6F7683388E5982E1");
        });

        modelBuilder.Entity<EstudianteMateria>(entity =>
        {
            entity.HasKey(e => e.EstudianteMateriaId).HasName("PK__Estudian__82F480DDCC8D2D17");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.EstudianteMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudiant__Estud__44FF419A");

            entity.HasOne(d => d.Materia).WithMany(p => p.EstudianteMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudiant__Mater__45F365D3");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materias__0D019D817A629EA6");
        });

        modelBuilder.Entity<ProfesorMateria>(entity =>
        {
            entity.HasKey(e => e.ProfesorMateriaId).HasName("PK__Profesor__731A63FFCC1D9A13");

            entity.HasOne(d => d.Materia).WithOne(p => p.ProfesorMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProfesorM__Mater__412EB0B6");

            entity.HasOne(d => d.Profesor).WithMany(p => p.ProfesorMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProfesorM__Profe__403A8C7D");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.ProfesorId).HasName("PK__Profesor__4DF3F0284C59EC73");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
