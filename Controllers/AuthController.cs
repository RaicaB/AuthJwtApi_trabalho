using AuthJwtApi.Models;
using AuthJwtApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthJwtApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private const string UsuarioFixo = "aluna";
    private const string SenhaFixa = "senha123";

    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Usuario != UsuarioFixo || request.Senha != SenhaFixa)
        {
            return Unauthorized(new { mensagem = "Usuário ou senha inválidos." });
        }

        var resposta = _tokenService.GerarToken(request.Usuario);
        return Ok(resposta);
    }
}
