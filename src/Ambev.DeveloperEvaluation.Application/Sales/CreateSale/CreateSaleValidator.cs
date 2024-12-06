using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(command => command.Number).NotEmpty().WithMessage("É necessário informar o número da venda");
            RuleFor(command => command.Branch).NotEmpty().WithMessage("É necessário informar a filial que fez a venda");
            RuleFor(command => command.SaleDate).NotEmpty().WithMessage("É necessário informar a data da venda");
            RuleFor(command => command.TotalSaleAmount).NotEmpty().WithMessage("É necessário informar o valor total da venda");
        }
    }
}
