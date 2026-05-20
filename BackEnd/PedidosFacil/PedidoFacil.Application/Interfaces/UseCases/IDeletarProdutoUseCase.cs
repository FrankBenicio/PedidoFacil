using PedidoFacil.Application.Responses;
using System;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface IDeletarProdutoUseCase
    {
        Task<ApiResponse<object>> ExecuteAsync(Guid id);
    }
}
