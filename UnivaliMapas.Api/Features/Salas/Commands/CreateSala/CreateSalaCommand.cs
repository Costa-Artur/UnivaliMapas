using MediatR;
using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommand : IRequest<CreateSalaDto>
{
    public int BlocoId { get; set; }
    public SalaForCreationDto Dto { get; set; } = new();
}