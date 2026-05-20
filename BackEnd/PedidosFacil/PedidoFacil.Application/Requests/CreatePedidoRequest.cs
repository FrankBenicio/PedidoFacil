using System.Collections.Generic;

namespace PedidoFacil.Application.Requests
{
    public class CreatePedidoRequest
    {
        public List<CreatePedidoItemRequest> Itens { get; set; }
    }
}
