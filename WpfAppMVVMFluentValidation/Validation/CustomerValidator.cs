using FluentValidation;

using WpfAppMVVMFluentValidation.Model;

namespace WpfAppMVVMFluentValidation.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format.");
    }
}
