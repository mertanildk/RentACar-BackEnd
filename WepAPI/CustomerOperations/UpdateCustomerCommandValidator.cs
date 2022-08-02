using FluentValidation;

namespace WepAPI.CustomerOperations
{
    public class UpdateCustomerCommandValidator: AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty();
            RuleFor(command => command.Model.CompanyName).MinimumLength(2);
            RuleFor(command => command.Model.UserId).NotEmpty();

        }
    }
}
