using FluentValidation;
using PedidoFacil.Application.Requests;
using PedidoFacil.Domain.Enums;

namespace PedidoFacil.Application.Validators
{
    public class UpdatePedidoStatusValidator : AbstractValidator<UpdatePedidoStatusRequest>
    {
        public UpdatePedidoStatusValidator()
        {
            RuleFor(x => x.Status)
                .Must(x => x == PedidoStatus.Pago || x == PedidoStatus.Cancelado)
                .WithMessage("Status permitido: Pago ou Cancelado.");
        }
    }
}
