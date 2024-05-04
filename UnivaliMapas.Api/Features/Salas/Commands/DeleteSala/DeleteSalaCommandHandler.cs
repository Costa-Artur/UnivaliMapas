using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Salas.Commands.DeleteSala;

public class DeleteSalaCommandHandler : IRequestHandler<DeleteSalaCommand, DeleteSalaDto>
{
    private readonly IUnivaliRepository _salaRepository;

    public DeleteSalaCommandHandler (IUnivaliRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task<DeleteSalaDto> Handle(DeleteSalaCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var salaFromDatabase = await _salaRepository.GetSalaByIdAsync(request.BlocoId, request.SalaId);

        if(salaFromDatabase != null) {
            _salaRepository.DeleteSala(salaFromDatabase);
            await _salaRepository.SaveChangesAsync();

            success = true;
        }

        return new DeleteSalaDto { Success = success };
    }   
}