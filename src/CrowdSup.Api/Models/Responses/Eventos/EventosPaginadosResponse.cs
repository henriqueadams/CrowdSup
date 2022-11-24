namespace CrowdSup.Api.Models.Responses.Eventos
{
    public class EventosPaginadosResponse
    {
        public IEnumerable<EventoResponse> Eventos { get; set; }
        public int Pagina { get; set; }

        public EventosPaginadosResponse(IEnumerable<EventoResponse> eventos, int pagina)
        {
            Eventos = eventos;
            Pagina = pagina;
        }
    }
}