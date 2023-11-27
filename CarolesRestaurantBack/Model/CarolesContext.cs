using System;
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

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<PedidoCliente> PedidoClientes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YV\\SQLEXPRESS;Initial Catalog=Caroles;Integrated Security=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC276501E4C8");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
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
            entity.HasKey(e => e.Id).HasName("PK__Codigos__3214EC27A698AFCC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoAleat)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funciona__3214EC277B850A9A");

            entity.ToTable("Funcionario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PedidoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoCl__3214EC274ECA900B");

            entity.ToTable("PedidoCliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoraPedido).HasColumnType("datetime");
            entity.Property(e => e.HoraPronto).HasColumnType("datetime");

            entity.HasOne(d => d.Produtos).WithMany(p => p.PedidoClientes)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoCli__Produ__403A8C7D");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3214EC27BD10B0E5");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Codigos).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CodigosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produtos__Codigo__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
