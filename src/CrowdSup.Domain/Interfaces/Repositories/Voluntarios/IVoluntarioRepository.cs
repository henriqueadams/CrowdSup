using CrowdSup.Domain.Entities.Voluntarios;

namespace CrowdSup.Domain.Interfaces.Repositories.Voluntarios
{
    public interface IVoluntarioRepository
    {
        Task InserirAsync(Voluntario voluntario);
        Task<Voluntario> ObterPorUsuarioAndEventoAsync(long Id, long eventoId);
    }
}