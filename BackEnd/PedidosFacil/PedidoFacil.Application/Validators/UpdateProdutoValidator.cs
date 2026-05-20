using FluentValidation;
using PedidoFacil.Application.Requests;

namespace PedidoFacil.Application.Validators
{
    public class UpdateProdutoValidator : AbstractValidator<UpdateProdutoRequest>
    {
        public UpdateProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(150).WithMessage("Nome deve possuir no máximo 150 caracteres.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero.");

            RuleFor(x => x.Estoque)
                .GreaterThanOrEqualTo(0).WithMessage("Estoque não pode ser negativo.");
        }
    }
}
