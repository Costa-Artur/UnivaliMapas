using MediatR;
using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommand : IRequest<CreateSalaCommandResponse>
{
    public SalaWithBlocoForCreationDto Dto { get; set; } = new();
}