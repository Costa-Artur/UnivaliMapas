using System.ComponentModel.DataAnnotations;

namespace UnivaliMapas.Api.Models;

public class AutenticacaoCodigoPessoaRequestDto
{
    [Required(ErrorMessage = "Voce deve preencher um codigo de pessoa")]
    public string? CodigoPessoa { get; set; }
    
    [Required(ErrorMessage = "Voce deve preencher uma senha")]
    public string? Password { get; set; }
}