using MediatR;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Usuarios.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreateUserCommandResponse>
{
    public UserForCreationDto Dto { get; set; } = new();
}