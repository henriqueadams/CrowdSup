using CrowdSup.Domain.Entities.Voluntarios;
using CrowdSup.Domain.Interfaces.Repositories.Voluntarios;
using CrowdSup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CrowdSup.Infra.Data.repositories.Voluntarios
{
    public class VoluntarioRepository : IVoluntarioRepository
    {
        private readonly CrowdsupContext _context;

        public VoluntarioRepository(CrowdsupContext comissoesContext)
            => _context = comissoesContext;

        public async Task InserirAsync(Voluntario voluntario)
        {
            await _context.AddAsync(voluntario);

            await _context.SaveChangesAsync();
        }

        public void Remover(Voluntario voluntario)
            => _context.Remove(voluntario);

        public async Task<Voluntario> ObterPorUsuarioAndEventoAsync(long usuarioId, long eventoId)
            => await _context.Voluntarios
                .FirstOrDefaultAsync(v => v.UsuarioId == usuarioId &&
                                          v.EventoId == eventoId);
    }
}