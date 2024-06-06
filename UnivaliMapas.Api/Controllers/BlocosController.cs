using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Blocos.Commands.CreateBloco;
using UnivaliMapas.Features.Blocos.Commands.DeleteBloco;
using UnivaliMapas.Features.Blocos.Commands.UpdateBloco;
using UnivaliMapas.Features.Blocos.Queries.GetBloco;


namespace UnivaliMapas.Api.Controllers;

[Route("api/blocos")]
public class BlocosController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlocosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet("{blocoID}", Name = "GetBlocoById")]
    public async Task<ActionResult> GetBloco(int blocoID)
    {
        var getBlocoDetailQuery = new GetBlocoDetailQuery { BlocoID = blocoID };
        var blocoToReturn = await _mediator.Send(getBlocoDetailQuery);

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }
    
    [HttpGet("com-sala/{blocoID}", Name = "GetBlocosWithSalaById")]
    public async Task<ActionResult <GetBlocoWithSalaDetailDto>> GetBlocoWithSalaById(int blocoID) 
    {
        var getBlocoDetailQuery = new GetBlocoWithSalaDetailQuery { BlocoID = blocoID };
        var blocoToReturn = await _mediator.Send(getBlocoDetailQuery);

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }
    
    [HttpPost]
    public async Task<ActionResult <BlocoDto>> CreateBloco (BlocoForCreationDto blocoForCreationDto) {
        var createBlocoCommand = new CreateBlocoCommand { Dto = blocoForCreationDto };
        var blocoToReturn = await _mediator.Send(createBlocoCommand);

        return CreatedAtRoute(
            "GetBlocoById",
            new { blocoID = blocoToReturn.BlocoID },
            blocoToReturn
        );   
    }
    
    [HttpPut("{blocoID}")]
    public async Task<ActionResult> UpdateBloco (int blocoID, char letraBloco) {

        var blocoForUpdateDto = new UpdateBlocoCommand { BlocoID = blocoID, LetraBLoco = letraBloco};
        var result = await  _mediator.Send(blocoForUpdateDto);

        if(result.Success == false) return NotFound();

        return NoContent();
    }

    [HttpDelete("{blocoID}")]
    public async Task<ActionResult> DeleteBloco(int blocoID) {
        var deleteBlocoCommand = new DeleteBlocoCommand {BlocoID = blocoID};
        var result = await _mediator.Send(deleteBlocoCommand);

        return result.Success ? NoContent() : NotFound();
    }
}