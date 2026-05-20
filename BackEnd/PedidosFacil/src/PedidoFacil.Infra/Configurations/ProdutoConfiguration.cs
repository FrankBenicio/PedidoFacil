using PedidoFacil.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PedidoFacil.Infrastructure.Configurations
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("Produtos");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Preco)
                .IsRequired()
                .HasPrecision(18, 2);

            Property(x => x.Estoque)
                .IsRequired();

            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsRequired();
        }
    }
}
