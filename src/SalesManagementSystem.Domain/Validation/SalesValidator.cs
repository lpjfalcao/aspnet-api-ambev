using SalesManagementSystem.Domain.Entities;
using FluentValidation;

namespace SalesManagementSystem.Domain.Validation
{
    public class OrdersValidator : AbstractValidator<Order>
    {
        public OrdersValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id da venda é um campo obrigatório");
        }
    }
}
