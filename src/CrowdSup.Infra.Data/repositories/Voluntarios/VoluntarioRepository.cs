using CrowdSup.Domain.Entities.Voluntarios;
using CrowdSup.Domain.Interfaces.Repositories.Voluntarios;
using CrowdSup.Infra.Data.Context;

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
    }
}