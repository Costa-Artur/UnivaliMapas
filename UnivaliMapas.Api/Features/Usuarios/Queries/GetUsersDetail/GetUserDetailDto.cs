using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Features.Usuarios.Queries.GetUsersDetail;

public class GetUserDetailDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CodigoPessoa { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}