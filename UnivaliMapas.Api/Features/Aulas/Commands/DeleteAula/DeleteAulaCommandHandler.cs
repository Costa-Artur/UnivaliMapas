using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Commands.DeleteAula;

public class DeleteAulaCommandHandler : IRequestHandler<DeleteAulaDto, DeleteAulaCommand>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public DeleteAulaCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}