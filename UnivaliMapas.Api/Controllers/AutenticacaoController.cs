using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UnivaliMapas.Api.Controllers;

[Route("api/autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AutenticacaoController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost("autenticar")]
    public ActionResult<string> AutenticarComCodigoPessoa(AutenticacaoCodigoPessoaRequestDto autenticacaoRequestDto)
    {
        var user = ValidateUserCredentialsFromCodigoPessoa(
            autenticacaoRequestDto.CodigoPessoa!,
            autenticacaoRequestDto.Password!
        );

        if (user == null)
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Authentication:SecretKey"]
                ?? throw new ArgumentNullException(nameof(_configuration))
            )
        );

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>();
        claims.Add(new Claim("sub", user.UserId.ToString()));
        claims.Add(new Claim("given_name", user.Name));

        var jwt = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],

            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        var jwtToReturn = new JwtSecurityTokenHandler().WriteToken(jwt);
        return Ok(jwtToReturn);
    }

    private InfoUser? ValidateUserCredentialsFromCodigoPessoa(string codigoPessoa, string password)
    {
        var userFromDatabase = new Entities.Usuario();

        if (userFromDatabase.CodigoPessoa == codigoPessoa && userFromDatabase.Password == password)
        {
            return new InfoUser(userFromDatabase.UserId, userFromDatabase.Cpf, userFromDatabase.CodigoPessoa, userFromDatabase.Name);
        }

        return null;
    }

    private class InfoUser
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CodigoPessoa { get; set; } = string.Empty;
        public string Cpf { get; set; } = String.Empty;

        public InfoUser(int userId, string cpf, string codigoPessoa, string name)
        {
            UserId = userId;
            Name = name;
            Cpf = cpf;
            CodigoPessoa = codigoPessoa;
        }
    }
}