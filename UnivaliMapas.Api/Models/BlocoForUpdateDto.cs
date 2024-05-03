using System.ComponentModel.DataAnnotations;
using MediatR;

namespace UnivaliMapas.Api.Models;

public class BlocoForUpdateDto : IRequest<BlocoForManipulationDto>
{
    [Required(ErrorMessage = "You should fill out an Id")]
    public int BlocoID {get; set;}
}