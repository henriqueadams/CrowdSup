using CrowdSup.Api.Models.Responses.Eventos;
using CrowdSup.Domain.Entities.Eventos;

namespace CrowdSup.Api.Models.Mappers.Eventos
{
    public class EventosPaginadosResponseMapper
    {
        public static EventosPaginadosResponse Map(IEnumerable<Evento> eventos, int pagina)
            => new EventosPaginadosResponse(EventoResponseMapper.Map(eventos), pagina);
    }
}