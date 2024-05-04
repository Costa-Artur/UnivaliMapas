using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Features.Salas.Commands.CreateSala;
using UnivaliMapas.Api.Features.Salas.Queries.GetSala;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Salas.Commands.DeleteSala;
using UnivaliMapas.Features.Salas.Commands.UpdateSala;

namespace UnivaliMapas.Api.Controllers;

[Route("api/blocos/{blocoId}/salas")]
public class SalasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalasController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{salaId}", Name = "GetSalaById")]
    public async Task<ActionResult<GetSalaDetailDto>> GetSalas(int salaId, int blocoId)
    {
        var getSalaDetailQuery = new GetSalaDetailQuery { 
            BlocoId = blocoId,
            Id = salaId 
        };
        var salaToReturn = await _mediator.Send(getSalaDetailQuery);

        return salaToReturn != null ? Ok(salaToReturn) : NotFound();
    }
    

    [HttpPost]
    public async Task<ActionResult<CreateSalaDto>> CreateSala(SalaWithBlocoForCreationDto salaForCreationDto)
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
    
    
    [HttpPut("{SalaId}")]
    public async Task<ActionResult> UpdateSalas(int blocoId, SalaForUpdateDto salaForUpdateDto)
    {
        var updateSalaCommand = new UpdateSalaCommand
        {
            BlocoId = blocoId, 
            Dto = salaForUpdateDto
        };
        var result = await  _mediator.Send(updateSalaCommand);

        return result.Success ? NoContent() : NotFound();
    }
    
    [HttpDelete("{salaId}")]
    public async Task<ActionResult> DeleteSala(int salaId, int blocoId) {
        var deleteSalaCommand = new DeleteSalaCommand
        {
            SalaId = salaId, 
            BlocoId = blocoId
        };
        var result = await _mediator.Send(deleteSalaCommand);

        return result.Success ? NoContent() : NotFound();
    }
}