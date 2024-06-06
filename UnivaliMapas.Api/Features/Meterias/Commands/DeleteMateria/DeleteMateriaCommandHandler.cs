using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Meterias.Commands.DeleteMateria;

public class DeleteMateriaCommandHandler : IRequestHandler<DeleteMateriaCommand, DeleteMateriaDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public DeleteMateriaCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
}