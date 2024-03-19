using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiDgii.Models;

public partial class DbdgiiContext : DbContext
{
    public DbdgiiContext()
    {
    }

    public DbdgiiContext(DbContextOptions<DbdgiiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComprobantesFiscale> ComprobantesFiscales { get; set; }

    public virtual DbSet<Contribuyente> Contribuyentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComprobantesFiscale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comproba__3213E83FF249C0EF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Itbis18)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("itbis18");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Ncf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NCF");
            entity.Property(e => e.RncCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rncCedula");

            entity.HasOne(d => d.RncCedulaNavigation).WithMany(p => p.ComprobantesFiscales)
                .HasForeignKey(d => d.RncCedula)
                .HasConstraintName("FK__Comproban__rncCe__5629CD9C");
        });

        modelBuilder.Entity<Contribuyente>(entity =>
        {
            entity.HasKey(e => e.RncCedula).HasName("PK__Contribu__38AA49B3EFA6C7D2");

            entity.Property(e => e.RncCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rncCedula");
            entity.Property(e => e.Estatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
