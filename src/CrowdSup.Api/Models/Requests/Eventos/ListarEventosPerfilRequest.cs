namespace CrowdSup.Api.Models.Requests.Eventos
{
    public class ListarEventosPerfilRequest
    {
        public int Pagina { get; set; }
        public long UsuarioId { get; set; }
    }
}