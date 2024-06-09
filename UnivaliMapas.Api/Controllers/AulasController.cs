using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Aulas.Commands.UpdateAula;
using UnivaliMapas.Features.Aulas.Queries.GetAulaByProfessor;
using UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

namespace UnivaliMapas.Api.Controllers;

[Route("api/aulas")]
[ApiController]
public class AulasController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AulasController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet ("student/{studentID}", Name = "GetAulaByStudent")]
    public async Task<ActionResult> GetAulaByStudent(int studentID)
    {
        var getAulaByStudentQuery = new GetAulaByStudentQuery { StudentID = studentID };
        var aulasToReturn = await _mediator.Send(getAulaByStudentQuery);
        foreach (var getAulaByStudentDto in aulasToReturn)
        {
            Console.WriteLine(getAulaByStudentDto.Materia.Name + "CONTROLLER");
        }
        
        if(aulasToReturn.IsNullOrEmpty())
        {
            return NotFound();
            
        }

        return Ok(aulasToReturn);
    }
    
    [HttpGet ("professor/{professorID}", Name = "GetAulaByProfessor")]
    public async Task<ActionResult> GetAulaByProfessor(int professorID)
    {
        var getAulaByProfessorQuery = new GetAulaByProfessorQuery { ProfessorID = professorID };
        var aulasToReturn = await _mediator.Send(getAulaByProfessorQuery);
        foreach (var getAulaByProfessorDto in aulasToReturn)
        {
            Console.WriteLine(getAulaByProfessorDto.Materia.Name + "CONTROLLER");
        }
        
        if(aulasToReturn.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Ok(aulasToReturn);
    }
    
    [HttpPut("{AulaId}")]
    public async Task<ActionResult> UpdateAula(int salaId, AulaForUpdateDto aulaForUpdateDto)
    {
        var updateAulaCommand = new UpdateAulaCommand
        {
            SalaId = salaId, 
            Dto = aulaForUpdateDto
        };
        var result = await  _mediator.Send(updateAulaCommand);

        return result.Success ? NoContent() : NotFound();
    }
}