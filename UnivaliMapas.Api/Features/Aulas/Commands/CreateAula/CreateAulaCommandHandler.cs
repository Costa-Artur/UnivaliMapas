using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Commands.CreateAula;

public class CreateAulaCommandHandler : IRequestHandler<CreateAulaCommand, CreateAulaDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public CreateAulaCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}