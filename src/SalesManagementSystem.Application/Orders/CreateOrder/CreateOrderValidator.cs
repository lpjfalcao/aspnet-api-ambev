using FluentValidation;

namespace SalesManagementSystem.Application.Orders.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(command => command.CustomerId).NotNull().WithMessage("É necessário informaro id do cliente");
            RuleFor(command => command.BranchId).NotNull().WithMessage("É necessário informar a filial onde o pedido foi feita");
            RuleFor(command => command.OrderItems).NotEmpty().WithMessage("É necessário informar os items do pedido");
        }
    }
}
