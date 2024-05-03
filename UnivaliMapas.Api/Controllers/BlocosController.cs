using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
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
    
    [HttpGet("{blocoID}", Name = "GetPublisherById")]
    public async Task<ActionResult <GetBlocoDetailDto>> GetBlocoById(int blocoID) {
        var getBlocoQuery = new GetBlocoWithSalaDetailQuery { BlocoID = blocoID };
        var blocoToReturn = await _mediator.Send(getBlocoQuery);

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }
    
    [HttpGet("com-sala/{blocoID}", Name = "GetBlocosWithSalaById")]
    public async Task<ActionResult <GetBlocoWithSalaDetailDto>> GetBlocoWithSalaById(int blocoID) 
    {
        var getBlocoDetailQuery = new GetBlocoWithSalaDetailQuery { BlocoID = blocoID };
        var blocoToReturn = await _mediator.Send(getBlocoDetailQuery);

        return blocoToReturn != null ? Ok(blocoToReturn) : NotFound();
    }
    
}