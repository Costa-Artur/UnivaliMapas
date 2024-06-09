using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Extensions;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Api.Controllers;

[Route("api/autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUnivaliRepository _repository;

    public AutenticacaoController(IConfiguration configuration, IUnivaliRepository repository)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpPost("autenticar")]
    public async Task<ActionResult<string>> AutenticarComCodigoPessoa(AutenticacaoCodigoPessoaRequestDto autenticacaoRequestDto)
    {
        var user = await ValidateUserCredentialsFromCodigoPessoa(
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
        claims.Add(new Claim("role", user.Role.ToString()));

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

    private async Task<InfoUser?> ValidateUserCredentialsFromCodigoPessoa(string codigoPessoa, string password)
    {
        var userFromDatabase = await _repository.GetUserByCodigoAsync(codigoPessoa);

        if (
            userFromDatabase != null && 
            userFromDatabase.CodigoPessoa == codigoPessoa && 
            userFromDatabase.Password == PasswordHasherExtension.ComputeHash(password, "salt", "pepper", 10))
        {
            return new InfoUser(userFromDatabase.UserId, userFromDatabase.Cpf, userFromDatabase.CodigoPessoa, userFromDatabase.Name, userFromDatabase.Role);
        }

        return null;
    }

    private class InfoUser
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CodigoPessoa { get; set; } = string.Empty;
        public string Cpf { get; set; } = String.Empty;
        
        public UserRole Role { get; set; }

        public InfoUser(int userId, string cpf, string codigoPessoa, string name, UserRole role)
        {
            UserId = userId;
            Name = name;
            Cpf = cpf;
            CodigoPessoa = codigoPessoa;
            Role = role;
        }
    }
}