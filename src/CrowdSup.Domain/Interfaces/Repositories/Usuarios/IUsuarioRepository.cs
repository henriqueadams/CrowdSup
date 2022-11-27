using CrowdSup.Domain.Entities.Usuarios;

namespace CrowdSup.Domain.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task InserirAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task<Usuario> ObterLoginAsync(string email, string senha);
        Task<Usuario> ObterAsync(long Id);
        Task<Usuario> ObterPorEmailAsync(string email);
    }
}