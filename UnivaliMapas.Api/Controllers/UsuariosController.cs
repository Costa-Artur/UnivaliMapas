using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Usuarios.Commands.CreateUser;

namespace UnivaliMapas.Api.Controllers;

[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserDto>> CreateUser(UserForCreationDto userForCreationDto)
    {
        var createUserCommand = new CreateUserCommand() { Dto = userForCreationDto };
        var userResponse = await _mediator.Send(createUserCommand);

        if (!userResponse.IsSuccess)
        {
            foreach (var error in userResponse.Errors)
            {
                string key = error.Key;
                string[] values = error.Value;

                foreach (var value in values)
                {
                    ModelState.AddModelError(key, value);
                }
            }

            return ValidationProblem(ModelState);
        }

        //return CreatedAtRoute(
        //    "GetUserById",
        //    new { userId = userResponse.User.UserId },
        //    userResponse.User
        //);

        return Ok(userResponse.User);
    }
}