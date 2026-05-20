using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface IObterProdutoPorIdUseCase
    {
        Task<ApiResponse<ProdutoResponse>> ExecuteAsync(Guid id);
    }
}
