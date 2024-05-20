using FluentValidation;

namespace UnivaliMapas.Features.Usuarios.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Dto.Name)
            .NotEmpty()
            .WithMessage("You should fill out a name");
    }
}