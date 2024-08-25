using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamBank.Models;

public partial class ExamBankContext : DbContext
{
    public ExamBankContext()
    {
    }

    public ExamBankContext(DbContextOptions<ExamBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandAmbassder> BrandAmbassders { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Institute> Institutes { get; set; }

    public virtual DbSet<Paper> Papers { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandAmbassder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BrandAmbassder_1");

            entity.ToTable("BrandAmbassder");

            entity.HasOne(d => d.Departmen).WithMany(p => p.BrandAmbassders)
                .HasForeignKey(d => d.DepartmenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BrandAmbassder_Department");

            entity.HasOne(d => d.Institute).WithMany(p => p.BrandAmbassders)
                .HasForeignKey(d => d.InstituteId)
                .HasConstraintName("FK_BrandAmbassder_Institute");

            entity.HasOne(d => d.User).WithMany(p => p.BrandAmbassders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_BrandAmbassder_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_department");

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Institue).WithMany(p => p.Departments)
                .HasForeignKey(d => d.InstitueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Department_Institute");
        });

        modelBuilder.Entity<Institute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Institue");

            entity.ToTable("Institute");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Paper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Paper_1");

            entity.ToTable("Paper");

            entity.HasOne(d => d.Ambassador).WithMany(p => p.Papers)
                .HasForeignKey(d => d.AmbassadorId)
                .HasConstraintName("FK_Paper_BrandAmbassder");

            entity.HasOne(d => d.Category).WithMany(p => p.Papers)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Paper_Category");

            entity.HasOne(d => d.Seasion).WithMany(p => p.Papers)
                .HasForeignKey(d => d.SeasionId)
                .HasConstraintName("FK_Paper_Session");

            entity.HasOne(d => d.Subject).WithMany(p => p.Papers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Paper_Subject");

            entity.HasOne(d => d.Year).WithMany(p => p.Papers)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_Paper_Year");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Session_1");

            entity.ToTable("Session");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Subject_Department");

            entity.HasOne(d => d.Institute).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.InstituteId)
                .HasConstraintName("FK_Subject_Institute");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RefreshToken).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.ToTable("Year");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
