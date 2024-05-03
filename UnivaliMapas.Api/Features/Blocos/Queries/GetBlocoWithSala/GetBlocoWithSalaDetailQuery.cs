using MediatR;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoWithSalaDetailQuery : IRequest<GetBlocoWithSalaDetailDto>
{
    public int BlocoID { get; set; }
}