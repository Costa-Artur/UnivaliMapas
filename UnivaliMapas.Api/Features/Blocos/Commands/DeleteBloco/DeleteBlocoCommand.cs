using MediatR;

namespace UnivaliMapas.Features.Blocos.Commands.DeleteBloco;

public class DeleteBlocoCommand : IRequest<DeleteBlocoDto>
{
    public int BlocoID { get; set; }
}