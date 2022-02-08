using FluentValidation;

namespace Trading.Web.Dto.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(model => model.Email).EmailAddress();

            RuleFor(model => model.Password).Must(x => x != null && x.Length > 3);
        }
    }
}
