using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DropDown.Models;

public partial class CodeFirstDbContext : DbContext
{
    public CodeFirstDbContext()
    {
    }

    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.ConformPassword)
                .HasMaxLength(100)
                .HasColumnName("Conform Password");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        modelBuilder.Entity<EmployeeInfo>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA79F272D632");

            entity.ToTable("EmployeeInfo");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmpFname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmpLname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeePosition");

            entity.Property(e => e.DateOfJoining)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpPosition)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Salary)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Emp).WithMany()
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__EmployeeP__EmpID__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
