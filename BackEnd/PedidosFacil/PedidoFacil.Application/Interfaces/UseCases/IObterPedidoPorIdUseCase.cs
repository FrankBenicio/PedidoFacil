using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface IObterPedidoPorIdUseCase
    {
        Task<ApiResponse<PedidoResponse>> ExecuteAsync(Guid id);
    }
}
