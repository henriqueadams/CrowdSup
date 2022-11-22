using CrowdSup.Domain.Entities.Usuarios;

namespace CrowdSup.Domain.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task InserirAsync(Usuario usuario);
        Task<Usuario> ObterLoginAsync(string email, string senha);
    }
}