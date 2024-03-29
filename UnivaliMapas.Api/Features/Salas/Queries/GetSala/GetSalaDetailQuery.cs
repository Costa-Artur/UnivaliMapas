using MediatR;

namespace UnivaliMapas.Api.Features.Salas.Queries.GetSala;

public class GetSalaDetailQuery : IRequest<GetSalaDetailDto>
{
    public int Id { get; set; }
}