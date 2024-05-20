using AutoMapper;
using FluentValidation;
using MediatR;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Usuarios.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserCommand> _validator;

    public CreateUserCommandHandler(IUnivaliRepository repository, IMapper mapper, IValidator<CreateUserCommand> validator)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandResponse createUserCommandResponse = new();

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.ToDictionary())
            {
                createUserCommandResponse.Errors.Add(error.Key, error.Value);
            }

            createUserCommandResponse.IsSuccess = false;
            return createUserCommandResponse;
        }

        var newUser = _mapper.Map<Usuario>(request.Dto);
        
        _repository.AddUser(newUser);
        await _repository.SaveChangesAsync();

        createUserCommandResponse.User = _mapper.Map<CreateUserDto>(newUser);

        return createUserCommandResponse;
    }
}