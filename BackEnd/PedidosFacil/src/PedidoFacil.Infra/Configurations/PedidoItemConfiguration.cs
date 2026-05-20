using PedidoFacil.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PedidoFacil.Infrastructure.Configurations
{
    public class PedidoItemConfiguration : EntityTypeConfiguration<PedidoItem>
    {
        public PedidoItemConfiguration()
        {
            ToTable("PedidoItens");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Quantidade).IsRequired();
            Property(x => x.ValorUnitario).IsRequired().HasPrecision(18, 2);
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsRequired();

            Ignore(x => x.ValorTotal);

            HasRequired(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId)
                .WillCascadeOnDelete(false);
        }
    }
}
