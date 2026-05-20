using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.Requests;
using PedidoFacil.Application.Responses;
using PedidoFacil.Application.Validators;
using PedidoFacil.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoFacil.Application.UseCases.Produtos
{
    public class CriarProdutoUseCase : ICriarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CreateProdutoValidator _validator;

        public CriarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _validator = new CreateProdutoValidator();
        }

        public async Task<ApiResponse<Guid>> ExecuteAsync(CreateProdutoRequest request)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                return ApiResponse<Guid>.Fail("Erros de validação", errors);
            }

            var produto = Produto.Create(
                request.Nome,
                request.Preco,
                request.Estoque
            );

            await _produtoRepository.AddAsync(produto);

            return ApiResponse<Guid>.Ok(
                produto.Id,
                "Produto cadastrado com sucesso."
            );
        }
    }
}
