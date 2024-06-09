using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;
using UnivaliMapas.Features.Meterias.Queries.GetMateria;

namespace UnivaliMapas.Features.Meterias.Commands.UpdateMateria;

public class UpdateMateriaCommandHandler //: IRequestHandler<UpdateMateriaCommand, UpdateMateriaDto>
    {
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public UpdateMateriaCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
}