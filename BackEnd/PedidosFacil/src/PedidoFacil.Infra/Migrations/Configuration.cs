namespace PedidoFacil.Infra.Migrations
{
    using PedidoFacil.Infrastructure.Persistence;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PedidoFacil.Infrastructure.Persistence.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PedidoFacil.Infrastructure.Persistence.AppDbContext context)
        {
            ProdutoSeed.Seed(context);
        }
    }
}
