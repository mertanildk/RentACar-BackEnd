using FluentValidation;

namespace WepAPI.CustomerOperations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>//reateCustomerCommand'ı valide eder
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.UserId).GreaterThan(0);
            RuleFor(command => command.Model.CompanyName).NotEmpty().MinimumLength(2);
            //RuleFor(command => command.Model.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
