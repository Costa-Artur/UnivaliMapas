namespace UnivaliMapas.Api.Features.Salas.Commands.CreateSala;

public class CreateSalaCommandResponse
{
    public bool IsSuccess { get; set; }
    public Dictionary<string, string[]> Errors { get; set; }
    public CreateSalaDto Sala { get; set; } = default!;
    
    public CreateSalaCommandResponse()
    {
        IsSuccess = true;
        Errors = new Dictionary<string, string[]>();
    }
}