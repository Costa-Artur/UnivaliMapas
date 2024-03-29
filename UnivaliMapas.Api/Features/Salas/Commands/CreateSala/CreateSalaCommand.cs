using MediatR;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommand : IRequest<CreateSalaCommandResponse>
{
    public SalaForCreationDto Dto { get; set; } = new SalaForCreationDto();
}