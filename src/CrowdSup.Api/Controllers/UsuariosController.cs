using System.Security.Claims;
using CrowdSup.Api.Models.Mappers.Usuarios;
using CrowdSup.Api.Models.Requests.Usuarios;
using CrowdSup.Api.Models.Responses.Usuarios;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdSup.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICollection<Claim> _claims;

        public UsuariosController(
            IUsuarioRepository usuarioRepository,
            IHttpContextAccessor context
        )
        {
            _usuarioRepository = usuarioRepository;
            _claims = context.HttpContext?.User?.Claims?.ToList();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsuarioResponse>> ObterAsync([FromQuery] ObterUsuarioRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            return UsuarioResponseMapper.Map(usuario);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> AtualizarAsync([FromBody] AtualizarUsuarioRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            usuario.Atualizar(request.Email, request.Cidade, request.Estado, request.Telefone);

            await _usuarioRepository.AtualizarAsync(usuario);

            return Ok();
        }
    }
}