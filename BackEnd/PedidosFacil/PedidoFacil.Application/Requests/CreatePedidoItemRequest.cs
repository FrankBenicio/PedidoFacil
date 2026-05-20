using System;

namespace PedidoFacil.Application.Requests
{
    public class CreatePedidoItemRequest
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
