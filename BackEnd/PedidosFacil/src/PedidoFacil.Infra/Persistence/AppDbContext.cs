using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Configurations;
using System.Data.Entity;

namespace PedidoFacil.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("PedidoFacilConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new PedidoItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
