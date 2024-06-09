using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Commands.UpdateAula;

public class UpdateAulaCommandHandler : IRequestHandler<UpdateAulaCommand, UpdateAulaDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAulaCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateAulaDto> Handle(UpdateAulaCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var aulaFromDatabase = await _repository.GetAulaByIdAsync(request.Dto.AulaId);

        if (aulaFromDatabase != null)
        {
            _repository.UpdateAula(aulaFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new UpdateAulaDto { Success = success };
    }
}