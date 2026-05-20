using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface IAtualizarProdutoUseCase
    {
        Task<ApiResponse<object>> ExecuteAsync(Guid id, UpdateProdutoRequest request);
    }
}
