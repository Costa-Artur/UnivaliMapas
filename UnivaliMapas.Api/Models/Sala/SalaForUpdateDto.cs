using System.ComponentModel.DataAnnotations;

namespace UnivaliMapas.Api.Models;

public class SalaForUpdateDto : SalaForManipulationDto
{
    [Required(ErrorMessage = "You should fill out an Id")]
    public int SalaId {get; set;}
}