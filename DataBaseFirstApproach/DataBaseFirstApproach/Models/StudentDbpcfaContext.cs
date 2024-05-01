using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstApproach.Models;

public partial class StudentDbpcfaContext : DbContext
{
    public StudentDbpcfaContext()
    {
    }

    public StudentDbpcfaContext(DbContextOptions<StudentDbpcfaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentId).HasColumnName("Student ID");
            entity.Property(e => e.StudentAge)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Age");
            entity.Property(e => e.StudentConfirmPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Confirm Password");
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Email");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Name");
            entity.Property(e => e.StudentNumer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Numer");
            entity.Property(e => e.StudentPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
