using gestorPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace gestorPedidos.Infra.Context
{
    public class GestorPedidosDbContext : DbContext
    {
        public GestorPedidosDbContext(DbContextOptions<GestorPedidosDbContext> options) : base(options) { }

        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Revenda
            modelBuilder.Entity<Revenda>()
                .HasIndex(r => r.Cnpj)
                .IsUnique();

            modelBuilder.Entity<Revenda>()
                .Property(r => r.Cnpj)
                .IsRequired();

            modelBuilder.Entity<Revenda>()
                .Property(r => r.RazaoSocial)
                .IsRequired();

            modelBuilder.Entity<Revenda>()
                .Property(r => r.NomeFantasia)
                .IsRequired();

            modelBuilder.Entity<Revenda>()
                .Property(r => r.Email)
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Contato)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ContatoId);

            // Contato
            modelBuilder.Entity<Contato>()
                .HasOne(c => c.Revenda)
                .WithMany(r => r.Contatos)
                .HasForeignKey(c => c.RevendaId);

            // Endereço
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Revenda)
                .WithMany(r => r.Enderecos)
                .HasForeignKey(e => e.RevendaId);
        }
    }
}
