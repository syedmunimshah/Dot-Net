using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FormDataBaseFirstApproach.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Emp__3214EC073AFDC8D1");

            entity.ToTable("Emp");

            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20);

            entity.HasOne(d => d.Gender).WithMany(p => p.Emps)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Emp__GenderId__4BAC3F29");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC07119E7C81");

            entity.ToTable("Gender");

            entity.Property(e => e.Name)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
