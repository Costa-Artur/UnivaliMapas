using AutoMapper;
using FluentValidation;
using MediatR;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Api.Repositories;
using UnivaliMapas.Features.Blocos.Commands.CreateBloco;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommandHandler : IRequestHandler<CreateSalaCommand, CreateSalaDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    // private readonly IValidator<CreateSalaCommand> _validator;
    
    public CreateSalaCommandHandler(IMapper mapper, IUnivaliRepository repository, IValidator<CreateSalaCommand> validator)
    {
        _mapper = mapper;
        _repository = repository;
        // _validator = validator;
    }
    
    public async Task<CreateSalaDto> Handle(CreateSalaCommand request, CancellationToken cancellationToken)
    {
        CreateSalaDto salaToReturn = null!;
        var blocoFromDatabase = await _repository.GetBlocoByIdAsync(request.BlocoId);

        if(blocoFromDatabase != null) {
            var salaWithoutBlocosDto = _mapper.Map<SalaForCreationDto>(request.Dto);
            var newSala = _mapper.Map<Sala>(salaWithoutBlocosDto);

            _repository.AddSala(blocoFromDatabase, newSala);
            await _repository.SaveChangesAsync();

            salaToReturn = _mapper.Map<CreateSalaDto>(newSala);
        }
        
        return salaToReturn;
    }
}