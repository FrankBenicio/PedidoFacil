using FluentValidation;
using PedidoFacil.Application.Requests;

namespace PedidoFacil.Application.Validators
{
    public class CreatePedidoItemValidator : AbstractValidator<CreatePedidoItemRequest>
    {
        public CreatePedidoItemValidator()
        {
            RuleFor(x => x.ProdutoId)
                .NotEmpty().WithMessage("Produto é obrigatório.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
        }
    }
}
