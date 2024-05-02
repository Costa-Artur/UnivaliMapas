using System.ComponentModel.DataAnnotations;

namespace UnivaliMapas.Api.Models;

public abstract class SalaForManipulationDto
{
    [Required(ErrorMessage = "You should fill out a Number")]
    public int Number { get; set; } 
}