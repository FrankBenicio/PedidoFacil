using PedidoFacil.Domain.Enums;
using PedidoFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> ListAsync(PedidoStatus? status);
        Task<Pedido> GetByIdAsync(Guid id);
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
    }
}
