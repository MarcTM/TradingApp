using FluentValidation;

namespace Trading.Web.Dto.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(model => model.Email)
                .EmailAddress().WithMessage("The field should be an email.");

            RuleFor(model => model.Password)
                .MinimumLength(4).WithMessage("The password must be longer than 3 characters.")
                .NotEmpty().WithMessage("You must enter the password.");

            RuleFor(model => model.RPassword)
                .MinimumLength(4).WithMessage("The password must be longer than 3 characters.")
                .NotEmpty().WithMessage("You must enter the password.")
                .Equal(model => model.Password).WithMessage("It should be the same as the pasword.");

            RuleFor(model => model.Username).Length(3, 15).WithMessage("Username should be between 3 and 15 characters.");

        }
    }
}
