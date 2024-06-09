using UnivaliMapas.Api.Repositories;
using AutoMapper;
using MediatR;

namespace UnivaliMapas.Features.Salas.Commands.UpdateSala;

public class UpdateSalaCommandHandler : IRequestHandler<UpdateSalaCommand, UpdateSalaCommandDto>
{
    private readonly IUnivaliRepository _salaRepository;
    private readonly IMapper _mapper;

    public UpdateSalaCommandHandler(IUnivaliRepository salaRepository, IMapper mapper)
    {
        _salaRepository = salaRepository ?? throw new ArgumentNullException(nameof(salaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateSalaCommandDto> Handle(UpdateSalaCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var salaFromDatabase = await _salaRepository.GetSalaByIdAsync(request.BlocoId, request.Dto.SalaId);

        if (salaFromDatabase != null)
        {
            _salaRepository.UpdateSala(salaFromDatabase, request.Dto);
            await _salaRepository.SaveChangesAsync();

            success = true;
        }

        return new UpdateSalaCommandDto { Success = success };
    }
}