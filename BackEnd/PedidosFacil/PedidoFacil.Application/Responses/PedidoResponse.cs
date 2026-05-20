using PedidoFacil.Domain.Enums;
using PedidoFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidoFacil.Application.Responses
{
    public class PedidoResponse
    {
        public Guid Id { get; set; }
        public PedidoStatus Status { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PedidoItemResponse> Itens { get; set; }

        public static implicit operator PedidoResponse(Pedido pedido)
        {
            return new PedidoResponse
            {
                Id = pedido.Id,
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal,
                CreatedAt = pedido.CreatedAt,
                Itens = pedido.Itens.Select(i => new PedidoItemResponse
                {
                    ProdutoId = i.ProdutoId,
                    ProdutoNome = i.Produto?.Nome,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    ValorTotal = i.ValorTotal
                }).ToList()
            };
        }
    }
}
