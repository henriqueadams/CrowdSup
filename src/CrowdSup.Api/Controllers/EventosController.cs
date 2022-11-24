using System.Security.Claims;
using CrowdSup.Api.Models.Mappers.Eventos;
using CrowdSup.Api.Models.Requests.Eventos;
using CrowdSup.Api.Models.Responses.Eventos;
using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Domain.Interfaces.Repositories.Eventos;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdSup.Api.Controllers
{
    [ApiController]
    [Route("eventos")]
    public class EventosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly ICollection<Claim> _claims;

        public EventosController(
            IUsuarioRepository usuarioRepository,
            IEventoRepository eventoRepository,
            IHttpContextAccessor context
        )
        {
            _usuarioRepository = usuarioRepository;
            _eventoRepository = eventoRepository;
            _claims = context.HttpContext?.User?.Claims?.ToList();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CriarAsync([FromBody] CriarEventoRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            var evento = new Evento(request.Titulo, request.Descricao, request.Endereco,
                request.DataEvento, request.QuantidadeVoluntariosNecessarios, usuario);

            await _eventoRepository.InserirAsync(evento);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<EventosPaginadosResponse> ListarAsync([FromQuery] ListarEventosRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            var eventos = await _eventoRepository.ListarAsync(usuario.Cidade, request.Pagina);

            return EventosPaginadosResponseMapper.Map(eventos, request.Pagina);
        }
    }
}