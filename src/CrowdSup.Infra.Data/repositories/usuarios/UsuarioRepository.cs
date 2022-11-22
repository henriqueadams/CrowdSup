using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Domain.Interfaces.Repositories.Usuarios;
using CrowdSup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CrowdSup.Infra.Data.repositories.usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CrowdsupContext _context;

        public UsuarioRepository(CrowdsupContext comissoesContext)
            => _context = comissoesContext;

        public async Task InserirAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterLoginAsync(string email, string senha)
            => await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
    }
}