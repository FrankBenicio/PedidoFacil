using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface ICriarPedidoUseCase
    {
        Task<ApiResponse<Guid>> ExecuteAsync(CreatePedidoRequest request);
    }
}
