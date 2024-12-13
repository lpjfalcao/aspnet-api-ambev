using FluentValidation;

namespace SalesManagementSystem.Application.Orders.UpdateOrder
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("O ID do pedido deve ser informado");
        }
    }
}
