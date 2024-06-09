using System.ComponentModel.DataAnnotations;

namespace UnivaliMapas.Api.Models;

public class BlocoForManipulationDto
{
    [Required(ErrorMessage = "You should fill out a Caracter")]
    public char LetraBloco { get; set; }
}