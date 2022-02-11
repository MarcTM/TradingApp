using FluentValidation;

namespace Trading.Web.Dto.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(model => model.Email)
                .EmailAddress().WithMessage("The field should be an email.");

            RuleFor(model => model.Password)
                .MinimumLength(4).WithMessage("The password must be longer than 3 characters.")
                .NotEmpty().WithMessage("You must enter the password.");
        }
    }
}
