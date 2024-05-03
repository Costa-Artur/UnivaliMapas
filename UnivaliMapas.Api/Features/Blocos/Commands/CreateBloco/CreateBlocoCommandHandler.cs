using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Blocos.Commands.CreateBloco;

public class CreateBlocoCommandHandler : IRequestHandler<CreateBlocoCommand, CreateBlocoDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public CreateBlocoCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CreateBlocoDto> Handle(CreateBlocoCommand request, CancellationToken cancellationToken)
    {
        var newBloco = _mapper.Map<Bloco>(request.Dto);

        _repository.AddBloco(newBloco);
        await _repository.SaveChangesAsync();

        var publisherToReturn = _mapper.Map<CreateBlocoDto>(newBloco);
        
        return publisherToReturn;
    }
}