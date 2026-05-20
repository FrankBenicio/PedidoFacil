using PedidoFacil.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PedidoFacil.Infrastructure.Configurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            ToTable("Pedidos");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Status).IsRequired();
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsRequired();

            Ignore(x => x.ValorTotal);

            HasMany(x => x.Itens)
                .WithRequired(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId)
                .WillCascadeOnDelete(true);
        }
    }
}
