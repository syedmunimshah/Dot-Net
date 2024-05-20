using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core_Web_API_CRUD_Operations.Models;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emp> Emps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-MP7NKC7\\SQLEXPRESS;Database=Student;Trusted_Connection=True;TrustServerCertificate=True;");
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Emp__3214EC073CC45965");

            entity.ToTable("Emp");

            entity.Property(e => e.Age)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Standard)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
