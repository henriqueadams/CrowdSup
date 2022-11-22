using CrowdSup.Domain.Entities.Usuarios;

namespace CrowdSup.Domain.Interfaces.DomainServices.Token
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}