using Microsoft.AspNetCore.Mvc;
using UnivaliMapas.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UnivaliMapas.Api.Extensions;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Api.Controllers;

[Route("api/autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUnivaliRepository _repository;
    private readonly string _pepper = "pepper";
    private readonly string _salt = "salt";
    private readonly int _iteration = 10;

    public AutenticacaoController(IConfiguration configuration, IUnivaliRepository repository)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _repository = repository;
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
        var userFromDatabase = await _repository.GetUserByCodigoPessoaAssync(codigoPessoa);

        if(userFromDatabase == null) return null;

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