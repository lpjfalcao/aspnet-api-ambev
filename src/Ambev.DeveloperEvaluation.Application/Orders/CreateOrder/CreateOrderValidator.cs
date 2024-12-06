using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("É necessário informar o id do cliente");
            RuleFor(command => command.BranchId).NotEmpty().WithMessage("É necessário informar o id da filial");
            RuleFor(command => command.OrderDate).NotEmpty().WithMessage("É necessário informar a data da venda");
            RuleFor(command => command.TotalAmount).NotEmpty().WithMessage("É necessário informar o valor total da venda");
            RuleFor(command => command.OrderItems).NotEmpty().WithMessage("É necessário informar os items do pedido");
        }
    }
}
