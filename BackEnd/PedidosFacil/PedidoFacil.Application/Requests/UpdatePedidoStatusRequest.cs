using PedidoFacil.Domain.Enums;

namespace PedidoFacil.Application.Requests
{
    public class UpdatePedidoStatusRequest
    {
        public PedidoStatus Status { get; set; }
    }
}
