using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Produto>> ListAsync()
        {
            return _context.Produtos.AsNoTracking().ToListAsync();
        }

        public Task<Produto> GetByIdAsync(Guid id)
        {
            return _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
