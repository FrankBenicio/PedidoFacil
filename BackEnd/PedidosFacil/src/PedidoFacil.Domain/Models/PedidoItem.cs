using PedidoFacil.Domain.Common;
using System;

namespace PedidoFacil.Domain.Models
{
    public class PedidoItem : BaseEntity
    {
        public Guid PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorTotal => Quantidade * ValorUnitario;

        private PedidoItem() { }

        public static PedidoItem Create(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            var item = new PedidoItem
            {
                Id = Guid.NewGuid(),
                ProdutoId = produto.Id,
                Produto = produto,
                Quantidade = quantidade,
                ValorUnitario = produto.Preco
            };

            item.SetCreatedAt();
            return item;
        }
    }
}
