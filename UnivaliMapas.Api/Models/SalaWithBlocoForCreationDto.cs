namespace UnivaliMapas.Api.Models;

public class SalaWithBlocoForCreationDto : SalaForCreationDto
{
    public List<BlocoDto> Blocos { get; set; } = new();
}