using PedidoFacil.Domain.Common;
using System;

namespace PedidoFacil.Domain.Models
{

    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        private Produto()
        {
        }

        public static Produto Create(
            string nome,
            decimal preco,
            int estoque)
        {
            return new Produto
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Preco = preco,
                Estoque = estoque,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void Atualizar(
            string nome,
            decimal preco,
            int estoque)
        {
            Nome = nome;
            Preco = preco;
            Estoque = estoque;

            SetUpdatedAt();
        }

        public void DebitarEstoque(int quantidade)
        {
            if (Estoque < quantidade)
                throw new Exception("Estoque insuficiente.");

            Estoque -= quantidade;

            SetUpdatedAt();
        }

        public void ReporEstoque(int quantidade)
        {
            Estoque += quantidade;

            SetUpdatedAt();
        }
    }
}
