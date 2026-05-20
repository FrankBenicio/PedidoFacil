using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Responses;
using PedidoFacil.Domain.Enums;
using PedidoFacil.Domain.Models;
using PedidosApi.Application.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Pedidos
{
    public class ListarPedidosUseCase : IListarPedidosUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ListarPedidosUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ApiResponse<List<PedidoResponse>>> ExecuteAsync(PedidoStatus? status)
        {
            List<Pedido> pedidos = await _pedidoRepository.ListAsync(status);

            List<PedidoResponse> response = pedidos.Select(x => (PedidoResponse)x).ToList();

            return ApiResponse<List<PedidoResponse>>.Ok(response);
        }
    }
}
