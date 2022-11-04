using FluentValidation;

namespace ProductsProject.Validators;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
        RuleFor(p => p.Price).GreaterThan(0).LessThanOrEqualTo(1000000);
    }
}
