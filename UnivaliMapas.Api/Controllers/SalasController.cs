using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Features.Salas.Commands.CreateSala;
using UnivaliMapas.Api.Features.Salas.Queries.GetSala;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Controllers;

[Route("api/salas")]
public class SalasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalasController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{salaId}", Name = "GetSalaById")]
    public async Task<ActionResult> GetSalas(int salaId)
    {
        var getSalaDetailQuery = new GetSalaDetailQuery { Id = salaId };
        var salaToReturn = await _mediator.Send(getSalaDetailQuery);

        return salaToReturn != null ? Ok(salaToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CreateSalaDto>> CreateSala(SalaForCreationDto salaForCreationDto)
    {
        var createSalaCommand = new CreateSalaCommand { Dto = salaForCreationDto };
        var salaResponse = await _mediator.Send(createSalaCommand);
        
        if(!salaResponse.IsSuccess)
        {
            foreach (var error in salaResponse.Errors)
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

        return CreatedAtRoute(
            "GetSalaById",
            new { salaId = salaResponse.Sala.SalaId },
            salaResponse.Sala
        );
    }
}