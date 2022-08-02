using FluentValidation;

namespace WepAPI.CustomerOperations
{

    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty().GreaterThan(0);
        }
    }
}
