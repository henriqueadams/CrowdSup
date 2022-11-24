using CrowdSup.Domain.Entities.Eventos;

namespace CrowdSup.Domain.Interfaces.Repositories.Eventos
{
    public interface IEventoRepository
    {
        Task InserirAsync(Evento evento);
        Task<IEnumerable<Evento>> ListarAsync(string cidade, int pagina);
    }
}