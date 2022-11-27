using CrowdSup.Api.Models.Mappers.Usuarios;
using CrowdSup.Api.Models.Responses.Eventos;
using CrowdSup.Domain.Entities.Eventos;

namespace CrowdSup.Api.Models.Mappers.Eventos
{
    public class EventoResponseMapper
    {
        public static IEnumerable<EventoResponse> Map(IEnumerable<Evento> eventos)
            => eventos.Select(Map);

        public static EventoResponse Map(Evento evento)
        {
            if (evento is null)
                return default;

            return new EventoResponse(evento.Id, evento.Titulo, evento.Descricao, evento.Endereco, evento.DataEvento,
                UsuarioResponseMapper.Map(evento.Organizador), evento.QuantidadeVoluntariosNecessarios, evento.QuantidadeParticipantes,
                evento.Cancelado, evento.Expirado, evento.VagasDisponiveis, evento.EstaNoEvento);
        }
    }
}