namespace UnivaliMapas.Features.Usuarios.Commands.CreateUser;

public class CreateUserDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CodigoPessoa { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}