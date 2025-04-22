using gestorPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Context
{
    public class GestorPedidosDbContext : DbContext
    {
        public GestorPedidosDbContext(DbContextOptions<GestorPedidosDbContext> options) : base(options) { }

        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoDistribuidor> PedidoDistribuidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Revenda)
                .WithMany(r => r.Pedidos)
                .HasForeignKey(p => p.RevendaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cliente>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);
            
            modelBuilder.Entity<Contato>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<Endereco>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<ItemPedido>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<Pedido>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<Produto>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<Revenda>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<Telefone>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);

            modelBuilder.Entity<PedidoDistribuidor>()
                .HasQueryFilter(e => !e.DeletedAt.HasValue);
        }
    }
}
