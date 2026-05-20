using FluentValidation;
using PedidoFacil.Application.Requests;

namespace PedidoFacil.Application.Validators
{
    public class CreatePedidoValidator : AbstractValidator<CreatePedidoRequest>
    {
        public CreatePedidoValidator()
        {
            RuleFor(x => x.Itens)
                .NotEmpty().WithMessage("Pedido deve possuir ao menos um item.");

            RuleForEach(x => x.Itens)
                .SetValidator(new CreatePedidoItemValidator());
        }
    }
}
