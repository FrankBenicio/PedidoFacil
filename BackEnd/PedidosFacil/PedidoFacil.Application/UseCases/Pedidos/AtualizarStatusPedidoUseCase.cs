using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using PedidoFacil.Application.Validators;
using PedidoFacil.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Pedidos
{
    public class AtualizarStatusPedidoUseCase : IAtualizarStatusPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly UpdatePedidoStatusValidator _validator;

        public AtualizarStatusPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _validator = new UpdatePedidoStatusValidator();
        }

        public async Task<ApiResponse<object>> ExecuteAsync(Guid id, UpdatePedidoStatusRequest request)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return ApiResponse<object>.Fail("Erros de Validação", errors);
            }

            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null)
                return ApiResponse<object>.Fail("Pedido não encontrado.");

            if (request.Status == PedidoStatus.Pago)
                pedido.MarcarComoPago();

            if (request.Status == PedidoStatus.Cancelado)
                pedido.Cancelar();

            await _pedidoRepository.UpdateAsync(pedido);

            return ApiResponse<object>.Ok(null, "Status atualizado com sucesso.");
        }
    }
}
