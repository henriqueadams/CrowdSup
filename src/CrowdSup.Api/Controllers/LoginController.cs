using CrowdSup.Api.Models.Requests.Logins;
using CrowdSup.Domain.Interfaces.DomainServices.Hash;
using CrowdSup.Domain.Interfaces.DomainServices.Token;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CrowdSup.Api.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public LoginController(
            IUsuarioRepository usuarioRepository,
            IHashService hashService,
            ITokenService tokenService
        )
        { 
            _usuarioRepository = usuarioRepository;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AutenticarAsync([FromBody] LoginRequest request)
        {
            var senhaCriptografada = _hashService.GerarMd5(request.Senha);

            var usuarioLogado = await _usuarioRepository.ObterLoginAsync(request.Email, senhaCriptografada);

            if (usuarioLogado is null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GerarToken(usuarioLogado);

            return token;
        }
    }
}