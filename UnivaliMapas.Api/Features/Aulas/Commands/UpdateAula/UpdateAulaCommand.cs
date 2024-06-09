using MediatR;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Aulas.Commands.UpdateAula;

public class UpdateAulaCommand : IRequest<UpdateAulaDto>
{
    public AulaForUpdateDto Dto { get; set; } = new();
}
