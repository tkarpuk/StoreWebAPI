using FluentValidation;
using StoreWebAPI.Features.ProductFeatures.Commands;

namespace StoreWebAPI.Features.ProductFeatures.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Product.Name).NotEmpty().WithMessage("Name can't by empty.");
            RuleFor(c => c.Product.Price).GreaterThan(0).WithMessage("Price needs to be more than 0.");
            RuleFor(c => c.Product.StoreId).GreaterThan(0).WithMessage("Product needs to have existing Id of Store.");
        }
    }
}
