using MediatR;

namespace UnivaliMapas.Features.Salas.Commands.DeleteSala;

public class DeleteSalaCommand : IRequest<DeleteSalaDto>
{
    public int SalaId { get; set; }
    public int BlocoId { get; set; }
}