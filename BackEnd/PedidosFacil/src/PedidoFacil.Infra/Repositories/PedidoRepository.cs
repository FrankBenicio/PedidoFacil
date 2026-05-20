using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Domain.Enums;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Pedido>> ListAsync(PedidoStatus? status)
        {
            var query = _context.Pedidos
                .Include(x => x.Itens.Select(i => i.Produto))
                .AsQueryable();

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            return query.AsNoTracking().ToListAsync();
        }

        public Task<Pedido> GetByIdAsync(Guid id)
        {
            return _context.Pedidos
                .Include(x => x.Itens.Select(i => i.Produto))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            await _context.SaveChangesAsync();
        }
    }
}
