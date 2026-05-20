using PedidoFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoFacil.Application.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ListAsync();
        Task<Produto> GetByIdAsync(Guid id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
