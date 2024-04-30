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
        _salaRepository = salaRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSalaCommandDto> Handle(UpdateSalaCommand request, CancellationToken cancellationToken)
    {
        var salaFromDatabase = await _salaRepository.GetSalaByIdAsync(request.SalaId);
        if(salaFromDatabase == null)
        {
            return new UpdateSalaCommandDto {Success = false};
        }
        _mapper.Map(request, salaFromDatabase);

        await _salaRepository.SaveChangesAsync();

        return new UpdateSalaCommandDto {Success = true};
    }
}