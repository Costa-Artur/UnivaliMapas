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
    
    
    /*public async Task<ActionResult <GetBlocoDetailDto>> GetBlocoById(int blocoID) {
        var getBlocoQuery = new GetBlocoDetailQuery { BlocoID = blocoID };
        var blocoToReturn = _mediator.Send(getBlocoQuery).Result;

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }*/
    
    [HttpGet("{blocoID}", Name = "GetBlocoById")]
    public async Task<ActionResult> GetBloco(int blocoID)
    {
        var getBlocoDetailQuery = new GetBlocoDetailQuery { BlocoID = blocoID };
        var blocoToReturn = await _mediator.Send(getBlocoDetailQuery);

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }
    
    [HttpGet("com-sala", Name = "GetBlocosWithSalaById")]
    public async Task<ActionResult <GetBlocoWithSalaDetailDto>> GetBlocoWithSalaById() 
    {
        var getBlocoDetailQuery = new GetBlocoWithSalaDetailQuery {};
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