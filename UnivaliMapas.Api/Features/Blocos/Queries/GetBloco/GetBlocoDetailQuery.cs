using MediatR;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoDetailQuery : IRequest<GetBlocoDetailDto>
{
    public int BlocoID { get; set; }
}