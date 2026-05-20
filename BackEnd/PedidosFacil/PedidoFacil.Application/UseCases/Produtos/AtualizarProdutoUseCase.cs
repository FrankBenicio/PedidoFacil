using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using PedidoFacil.Application.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Produtos
{
    public class AtualizarProdutoUseCase : IAtualizarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly UpdateProdutoValidator _validator;

        public AtualizarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _validator = new UpdateProdutoValidator();
        }

        public async Task<ApiResponse<object>> ExecuteAsync(Guid id, UpdateProdutoRequest request)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                return ApiResponse<object>.Fail("Erros de validação", errors);
            }

            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto == null)
                return ApiResponse<object>.Fail("Produto não encontrado.");

            produto.Atualizar(
                request.Nome,
                request.Preco,
                request.Estoque
            );

            await _produtoRepository.UpdateAsync(produto);

            return ApiResponse<object>.Ok(
                null,
                "Produto atualizado com sucesso."
            );
        }
    }
}
