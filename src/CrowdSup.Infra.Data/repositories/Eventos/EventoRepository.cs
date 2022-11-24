using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Domain.Interfaces.Repositories.Eventos;
using CrowdSup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CrowdSup.Infra.Data.repositories.Eventos
{
    public class EventoRepository : IEventoRepository
    {
        private readonly CrowdsupContext _context;

        public EventoRepository(CrowdsupContext comissoesContext)
            => _context = comissoesContext;

        public async Task InserirAsync(Evento evento)
        {
            await _context.AddAsync(evento);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Evento evento)
        {
            await Task.Run(() => _context.Update(evento));

            await _context.SaveChangesAsync();
        }

        public async Task<Evento> ObterAsync(long Id)
            => await _context.Eventos
                .Include(e => e.Voluntarios)
                .FirstOrDefaultAsync(e => e.Id == Id);

        public async Task<IEnumerable<Evento>> ListarAsync(string cidade, int pagina)
        {
            var eventos = await _context.Eventos
                .Include(e => e.Organizador)
                .Include(e => e.Voluntarios)
                .Where(e => e.Endereco.Cidade == cidade)
                .OrderByDescending(e => e.DataEvento)
                .ToListAsync();

            var eventosAtivos = eventos.Where(e => e.Ativo).ToList();

            var tamanhoPagina = 10;
            var eventosPaginados = new List<Evento>();
            var inicioPagina = (tamanhoPagina * pagina) - tamanhoPagina;
            for (int i = inicioPagina; i < inicioPagina + tamanhoPagina; i++)
            {
                if (eventosAtivos.Count <= i)
                    break;

                eventosPaginados.Add(eventosAtivos[i]);
            }

            return eventosPaginados;
        }
    }
}