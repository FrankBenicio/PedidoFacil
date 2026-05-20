using PedidoFacil.Domain.Common;
using PedidoFacil.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidoFacil.Domain.Models
{
    public class Pedido : BaseEntity
    {
        public PedidoStatus Status { get; private set; }
        public virtual ICollection<PedidoItem> Itens { get; private set; }
        public decimal ValorTotal => Itens.Sum(x => x.ValorTotal);

        private Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public static Pedido Create()
        {
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Status = PedidoStatus.Pendente
            };

            pedido.SetCreatedAt();
            return pedido;
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (Status == PedidoStatus.Cancelado)
                throw new InvalidOperationException("Não é possível alterar um pedido cancelado.");

            produto.DebitarEstoque(quantidade);
            Itens.Add(PedidoItem.Create(produto, quantidade));
            SetUpdatedAt();
        }

        public void MarcarComoPago()
        {
            if (!Itens.Any())
                throw new InvalidOperationException("Pedido sem itens.");

            if (Status == PedidoStatus.Cancelado)
                throw new InvalidOperationException("Pedido cancelado não pode ser pago.");

            Status = PedidoStatus.Pago;
            SetUpdatedAt();
        }

        public void Cancelar()
        {
            if (Status == PedidoStatus.Cancelado)
                throw new InvalidOperationException("Pedido já está cancelado.");

            foreach (var item in Itens)
                item.Produto?.ReporEstoque(item.Quantidade);

            Status = PedidoStatus.Cancelado;
            SetUpdatedAt();
        }
    }
}
