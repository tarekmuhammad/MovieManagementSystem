using FluentValidation;
using MovieSystem.Application.DTO;
 
namespace MovieSystem.Application.Validations
{
    public class UserValidation : AbstractValidator<UserCreateDto>
    {
        public UserValidation() {
        RuleFor(user => user.Name)
                .NotEmpty().WithMessage("User Name Is Required")
                .MinimumLength(4).WithMessage("")
                .MaximumLength(50).WithMessage("");

            RuleFor(user => user.Email).EmailAddress().WithMessage("invalid email");
        }

    }
}
