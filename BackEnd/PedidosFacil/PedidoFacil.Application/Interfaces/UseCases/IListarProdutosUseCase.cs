using PedidoFacil.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.UseCases
{
    public interface IListarProdutosUseCase
    {
        Task<ApiResponse<List<ProdutoResponse>>> ExecuteAsync();
    }
}
