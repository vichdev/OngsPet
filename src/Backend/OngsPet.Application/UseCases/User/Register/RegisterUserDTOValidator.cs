using FluentValidation;
using OngsPet.Communication.Requests;
using OngsPet.Exceptions;

namespace OngsPet.Application.UseCases.User.Register
{
    public class RegisterUserDTOValidator : AbstractValidator<RequestRegisterUserDTO>
    {
        public RegisterUserDTOValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage(string.Format(ResourcesMessagesException.REQUIRED, "Nome"));

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(string.Format(ResourcesMessagesException.REQUIRED, "E-mail"));

            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Senha deve possuir pelo menos 6 caracteres");

        }

    }
}
