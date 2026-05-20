using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Pedidos
{
    public class ObterPedidoPorIdUseCase : IObterPedidoPorIdUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ObterPedidoPorIdUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ApiResponse<PedidoResponse>> ExecuteAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null)
                return ApiResponse<PedidoResponse>.Fail("Pedido não encontrado.");

            return ApiResponse<PedidoResponse>.Ok(pedido);
        }
    }
}
