using FluentValidation;

namespace Trading.Web.Dto.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(model => model.Email).EmailAddress();

            RuleFor(model => model.Username).Must(x => x != null && x.Length > 3 && x.Length < 15);

            RuleFor(model => model.Password).Must(x => x != null && x.Length > 3);

            RuleFor(model => model.RPassword).Must(x => x != null && x.Length > 3);
        }
    }
}
