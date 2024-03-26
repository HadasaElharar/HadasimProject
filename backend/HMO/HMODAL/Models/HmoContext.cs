using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HmoDAL.Models;

public partial class HmoContext : DbContext
{
    public HmoContext()
    {
    }

    public HmoContext(DbContextOptions<HmoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HmoMember> HmoMembers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Sick> Sicks { get; set; }

    public virtual DbSet<Vaccinated> Vaccinateds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NGJCGRF;Database= HMO;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HmoMember>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Sick>(entity =>
        {
            entity.ToTable("Sick");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Member).WithMany(p => p.Sicks)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sick_HmoMembers");
        });

        modelBuilder.Entity<Vaccinated>(entity =>
        {
            entity.ToTable("Vaccinated");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Vaccinateds)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccinated_Maufacturer");

            entity.HasOne(d => d.Member).WithMany(p => p.Vaccinateds)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccinated_HmoMembers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
