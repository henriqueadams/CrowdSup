using System.Security.Claims;
using CrowdSup.Api.Models.Mappers.Eventos;
using CrowdSup.Api.Models.Requests.Eventos;
using CrowdSup.Api.Models.Responses.Eventos;
using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Domain.Entities.Voluntarios;
using CrowdSup.Domain.Interfaces.Repositories.Eventos;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using CrowdSup.Domain.Interfaces.Repositories.Voluntarios;
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
        private readonly IVoluntarioRepository _voluntarioRepository;
        private readonly ICollection<Claim> _claims;

        public EventosController(
            IUsuarioRepository usuarioRepository,
            IEventoRepository eventoRepository,
            IVoluntarioRepository voluntarioRepository,
            IHttpContextAccessor context
        )
        {
            _usuarioRepository = usuarioRepository;
            _eventoRepository = eventoRepository;
            _voluntarioRepository = voluntarioRepository;
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

            var voluntario = new Voluntario(usuario, evento);

            await _voluntarioRepository.InserirAsync(voluntario);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<EventosPaginadosResponse> ListarAsync([FromQuery] ListarEventosRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            var eventos = await _eventoRepository.ListarAsync(usuario.Cidade, request.Pagina);

            foreach (var evento in eventos)
                evento.UsuarioEstaNoEvento(usuario.Id);

            return EventosPaginadosResponseMapper.Map(eventos, request.Pagina);
        }

        [HttpGet("pesquisar")]
        [Authorize]
        public async Task<EventosPaginadosResponse> ListarPesquisaAsync([FromQuery] ListarEventosPesquisaRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var eventos = await _eventoRepository.ListarAsync(request.Cidade, request.Pagina);

            foreach (var evento in eventos)
                evento.UsuarioEstaNoEvento(Int32.Parse(id));

            return EventosPaginadosResponseMapper.Map(eventos, request.Pagina);
        }

        [HttpGet("perfil")]
        [Authorize]
        public async Task<ActionResult<EventosPaginadosResponse>> ListarPerfilAsync([FromQuery] ListarEventosPerfilRequest request)
        {
            var usuarioLogadoId = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(request.UsuarioId);
            if (usuario is null)
                return BadRequest("Usuário não encontrado");

            var eventos = await _eventoRepository.ListarPorUsuarioAsync(usuario.Id, request.Pagina);

            foreach (var evento in eventos)
                evento.UsuarioEstaNoEvento(Int32.Parse(usuarioLogadoId));

            return EventosPaginadosResponseMapper.Map(eventos, request.Pagina);
        }

        [HttpPost("join")]
        [Authorize]
        public async Task<ActionResult> ParticiarEventoAsync([FromQuery] ParticiparRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            var evento = await _eventoRepository.ObterAsync(request.EventoId);
            if (evento is null)
                return BadRequest("Não foi possível participar do evento");

            if (evento.Voluntarios.Any(v => v.UsuarioId == usuario.Id))
                return BadRequest("Você já está participante desse evento");

            if (!evento.VagasDisponiveis)
                return BadRequest("Esse evento já está lotado");

            var voluntario = new Voluntario(usuario, evento);

            await _voluntarioRepository.InserirAsync(voluntario);

            return Ok();
        }

        [HttpPut("cancelar")]
        [Authorize]
        public async Task<ActionResult> CancelarAsync([FromBody] CancelarEventoRequest request)
        {
            var id = _claims?.FirstOrDefault(c => c.Type.ToUpper() == "ID")?.Value;

            var usuario = await _usuarioRepository.ObterAsync(Int32.Parse(id));

            var evento = await _eventoRepository.ObterAsync(request.EventoId);
            if (evento is null)
                return BadRequest("Não foi possível obter o evento");

            if (evento.OrganizadorId == usuario.Id)
                evento.Cancelar();
            else
            {
                evento.UsuarioEstaNoEvento(usuario.Id);

                if (!evento.EstaNoEvento)
                    return BadRequest("Você não está participante do evento");

                var voluntario = await _voluntarioRepository.ObterPorUsuarioAndEventoAsync(usuario.Id, evento.Id);
                
                evento.RemoverVoluntario(voluntario);
            }

            await _eventoRepository.AtualizarAsync(evento);

            return Ok();
        }
    }
}