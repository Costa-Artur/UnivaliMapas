using MediatR;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Blocos.Commands.CreateBloco;

public class CreateBlocoCommand : IRequest<CreateBlocoDto>
{
    public BlocoForCreationDto Dto { get; set; } = new ();
}