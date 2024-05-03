using MediatR;

namespace UnivaliMapas.Features.Blocos.Commands.UpdateBloco;

public class UpdateBlocoCommand : IRequest<UpdateBlocoDto>
{
    public int BlocoID { get; set; } = new();
    public char LetraBLoco { get; set; }
}