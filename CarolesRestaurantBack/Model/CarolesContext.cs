﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarolesRestaurantBack.Model;

public partial class CarolesContext : DbContext
{
    public CarolesContext()
    {
    }

    public CarolesContext(DbContextOptions<CarolesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Codigo> Codigos { get; set; }

    public virtual DbSet<PedidoCliente> PedidoClientes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YV\\SQLEXPRESS;Initial Catalog=Caroles;Integrated Security=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC27405F70F7");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("isAdmin");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Codigo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Codigos__3214EC27C54DE5E3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoAleat)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PedidoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoCl__3214EC27E9C377CF");

            entity.ToTable("PedidoCliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoraPedido).HasColumnType("datetime");
            entity.Property(e => e.HoraPronto).HasColumnType("datetime");

            entity.HasOne(d => d.Produtos).WithMany(p => p.PedidoClientes)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoCli__Produ__3E52440B");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3214EC271C19951E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Codigos).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CodigosId)
                .HasConstraintName("FK__Produtos__Codigo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
