using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface ICriarProdutoUseCase
    {
        Task<ApiResponse<Guid>> ExecuteAsync(CreateProdutoRequest request);
    }
}
