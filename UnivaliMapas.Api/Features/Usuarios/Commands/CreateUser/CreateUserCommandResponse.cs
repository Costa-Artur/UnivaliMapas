namespace UnivaliMapas.Features.Usuarios.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public bool IsSuccess { get; set; }
    public Dictionary<string, string[]> Errors { get; set; }
    public CreateUserDto User { get; set; } = default!;

    public CreateUserCommandResponse()
    {
        IsSuccess = true;
        Errors = new Dictionary<string, string[]>();
    }
}