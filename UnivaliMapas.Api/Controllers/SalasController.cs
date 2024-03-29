using Microsoft.AspNetCore.Mvc;

namespace UnivaliMapas.Api.Controllers;

[Route("api/salas")]
public class SalasController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetSalas()
    {
        return Ok();
    }        
}