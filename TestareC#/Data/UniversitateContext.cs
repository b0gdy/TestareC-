using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestareC_.Models;

namespace TestareC_.Data;

public partial class UniversitateContext : DbContext
{
    public UniversitateContext()
    {
    }

    public UniversitateContext(DbContextOptions<UniversitateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grupa> Grupas { get; set; }

    public virtual DbSet<Materie> Materies { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Orase> Orases { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BOGDAN-ASUS\\MSSQLSERVER1;Initial Catalog=Universitate;Persist Security Info=True;User ID=MyLogin;Password=Password1;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Romanian_CP1250_CS_AS");

        modelBuilder.Entity<Grupa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grupa__3214EC072455EA37");

            entity.ToTable("Grupa");

            entity.Property(e => e.Denumire).HasMaxLength(255);
        });

        modelBuilder.Entity<Materie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materie__3214EC07EC950E30");

            entity.ToTable("Materie");

            entity.Property(e => e.Nume).HasMaxLength(255);

        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Note__3214EC07C3D455C5");

            entity.ToTable("Note");

            entity.Property(e => e.MaterieId).HasColumnName("Materie_Id");
            entity.Property(e => e.NotaObtinuta).HasColumnName("Nota_obtinuta");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");

            entity.HasOne(d => d.Materie).WithMany(p => p.Notes)
                .HasForeignKey(d => d.MaterieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Note__Materie_Id__5629CD9C");

            entity.HasOne(d => d.Student).WithMany(p => p.Notes)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Note__Student_Id__5535A963");

        });

        modelBuilder.Entity<Orase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orase__3214EC07CEB44483");

            entity.ToTable("Orase");

            entity.Property(e => e.Denumire).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0785367ED3");

            entity.ToTable("Student");

            entity.Property(e => e.GrupaId).HasColumnName("Grupa_Id");
            entity.Property(e => e.Nume).HasMaxLength(255);
            entity.Property(e => e.OrasId).HasColumnName("Oras_Id");
            entity.Property(e => e.Prenume).HasMaxLength(255);

            entity.HasOne(d => d.Grupa).WithMany(p => p.Students)
                .HasForeignKey(d => d.GrupaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__Grupa_I__49C3F6B7");

            entity.HasOne(d => d.Oras).WithMany(p => p.Students)
                .HasForeignKey(d => d.OrasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__Oras_Id__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
