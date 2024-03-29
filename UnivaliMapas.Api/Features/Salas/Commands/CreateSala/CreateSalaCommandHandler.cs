using AutoMapper;
using FluentValidation;
using MediatR;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommandHandler : IRequestHandler<CreateSalaCommand, CreateSalaCommandResponse>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSalaCommand> _validator;
    
    public CreateSalaCommandHandler(IMapper mapper, IUnivaliRepository repository, IValidator<CreateSalaCommand> validator)
    {
        _mapper = mapper;
        _repository = repository;
        _validator = validator;
    }
    
    public async Task<CreateSalaCommandResponse> Handle(CreateSalaCommand request, CancellationToken cancellationToken)
    {
        CreateSalaCommandResponse createSalaCommandResponse = new();
        
        var validationResult = _validator.Validate(request);
        
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.ToDictionary())
            {
                createSalaCommandResponse.Errors.Add(error.Key, error.Value);
            }
            
            createSalaCommandResponse.IsSuccess = false;
            return createSalaCommandResponse;
        }

        var newSala = _mapper.Map<Sala>(request.Dto);
        
        _repository.AddSala(newSala);
        await _repository.SaveChangesAsync();

        createSalaCommandResponse.Sala = _mapper.Map<CreateSalaDto>(newSala);
        return createSalaCommandResponse;
    }
}