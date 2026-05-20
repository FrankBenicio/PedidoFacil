using PedidoFacil.Application.Responses;
using PedidoFacil.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PedidosApi.Application.Interfaces.UseCases
{
    public interface IListarPedidosUseCase
    {
        Task<ApiResponse<List<PedidoResponse>>> ExecuteAsync(PedidoStatus? status);
    }
}