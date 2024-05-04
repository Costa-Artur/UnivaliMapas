using FluentValidation;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommandValidator : AbstractValidator<CreateSalaCommand>
{
   public CreateSalaCommandValidator()
    {
        RuleFor(s => s.Dto.Number)
            .NotEmpty()
            .WithMessage("You should fill out a Number")
            .When(s => s.Dto.Number < 0)
            .WithMessage("Number should be greater than 0");
    }
}