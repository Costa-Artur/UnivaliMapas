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

    
}