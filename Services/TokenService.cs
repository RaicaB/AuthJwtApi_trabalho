using System.Security.Claims;
using System.Text;
using AuthJwtApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace AuthJwtApi.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public LoginResponse GerarToken(string nomeUsuario)
    {
        var chave = _configuration["Jwt:Key"]!;
        var emissor = _configuration["Jwt:Issuer"];
        var audiencia = _configuration["Jwt:Audience"];
        var minutos = int.Parse(_configuration["Jwt:ExpiraEmMinutos"] ?? "30");

        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, nomeUsuario),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
        var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);
        var expiraEm = DateTime.UtcNow.AddMinutes(minutos);

        var token = new JwtSecurityToken(
            issuer: emissor,
            audience: audiencia,
            claims: claims,
            expires: expiraEm,
            signingCredentials: credenciais);

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiraEm = expiraEm
        };
    }
}