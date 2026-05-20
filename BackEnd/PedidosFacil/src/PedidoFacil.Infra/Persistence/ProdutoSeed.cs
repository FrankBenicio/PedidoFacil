using PedidoFacil.Domain.Models;
using System.Linq;

namespace PedidoFacil.Infrastructure.Persistence
{
    public static class ProdutoSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Produtos.Any())
                return;

            context.Produtos.Add(
                Produto.Create(
                    "Notebook",
                    5000m,
                    5));

            context.SaveChanges();
        }
    }
}
