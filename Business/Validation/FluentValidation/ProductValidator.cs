using Business.Common.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class AddProductValidator : AbstractValidator<Product>
    {
        public AddProductValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage(Messages.RequestNotEmpty);

            When(x => x != null, () =>
               {
                   RuleFor(x => x.ProductName)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage(Messages.ProductNameNotEmpty);
               });


        }
    }
}
