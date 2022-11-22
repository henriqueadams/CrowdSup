using CrowdSup.Api.Models.Requests.Usuarios;
using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Domain.Interfaces.DomainServices.Hash;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CrowdSup.Api.Controllers
{
    [ApiController]
    [Route("cadastro")]
    public class CadastroController : ControllerBase
    {
        private readonly IHashService _hashService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastroController(
            IHashService hashService,
            IUsuarioRepository usuarioRepository
        )
        {
            _hashService = hashService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync([FromBody] CadastrarUsuarioRequest request)
        {
            if (request.Senha.Length < 8)
                return BadRequest("Senha deve ter ao menos 8 caracteres");

            var senhaCriptografada = _hashService.GerarMd5(request.Senha);

            var usuario = new Usuario(request.Nome, request.Email, senhaCriptografada, request.DataNascimento, 
                request.Cidade, request.Estado, request.Telefone, request.Sexo);

            await _usuarioRepository.InserirAsync(usuario);

            return Ok();
        }
    }
}