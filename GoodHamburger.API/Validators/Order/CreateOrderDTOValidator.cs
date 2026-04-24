using FluentValidation;
using GoodHamburger.Application.DTOs.Orders.Requests;

namespace GoodHamburger.API.Validators.Order;

public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
{
    public CreateOrderDTOValidator()
    {
        RuleForEach(x => x.OrderItems).ChildRules(child =>
        {
            child.RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("O ProductId deve ser maior que 0.");

            child.RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage($"A Quantity deve ser maior que 0.");
        });
    }

}