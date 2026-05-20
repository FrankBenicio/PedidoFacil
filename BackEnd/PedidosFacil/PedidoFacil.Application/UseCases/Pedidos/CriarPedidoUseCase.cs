using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using PedidoFacil.Application.Validators;
using PedidoFacil.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Pedidos
{
    public class CriarPedidoUseCase : ICriarPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly CreatePedidoValidator _validator;

        public CriarPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _validator = new CreatePedidoValidator();
        }

        public async Task<ApiResponse<Guid>> ExecuteAsync(CreatePedidoRequest request)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return ApiResponse<Guid>.Fail("Erros de Validação", errors);
            }

            var pedido = Pedido.Create();

            foreach (var itemRequest in request.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(itemRequest.ProdutoId);

                if (produto == null)
                    return ApiResponse<Guid>.Fail($"Produto {itemRequest.ProdutoId} não encontrado.");

                pedido.AdicionarItem(produto, itemRequest.Quantidade);
            }

            await _pedidoRepository.AddAsync(pedido);

            return ApiResponse<Guid>.Ok(pedido.Id, "Pedido cadastrado com sucesso.");
        }
    }
}
