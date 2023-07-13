using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestProjectAPI.Models;

public partial class TestProjectContext : DbContext
{
    public TestProjectContext()
    {
    }

    public TestProjectContext(DbContextOptions<TestProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<GetRand> GetRands { get; set; }

    public virtual DbSet<Name> Names { get; set; }

    public virtual DbSet<Surname> Surnames { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LEGION;Database=TestProject;TrustServerCertificate=True;User Id=sa;Password=sas;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("CITIES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Plate).HasColumnName("PLATE");
        });

        modelBuilder.Entity<GetRand>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetRand");
        });

        modelBuilder.Entity<Name>(entity =>
        {
            entity.ToTable("NAMES");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name1)
                .HasMaxLength(100)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Surname>(entity =>
        {
            entity.ToTable("SURNAMES");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Surname1)
                .HasMaxLength(100)
                .HasColumnName("SURNAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("WORKERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Barcode).HasColumnName("BARCODE");
            entity.Property(e => e.BIRTHDATE)
                .HasColumnType("datetime")
                .HasColumnName("BIRTHDATE");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("GENDER");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("SURNAME");
            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .HasColumnName("TCNO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
