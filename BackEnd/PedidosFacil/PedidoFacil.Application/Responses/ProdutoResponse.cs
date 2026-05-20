using PedidoFacil.Domain.Models;
using System;

namespace PedidoFacil.Application.Responses
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public static implicit operator ProdutoResponse(Produto produto)
        {
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };
        }
    }
}
