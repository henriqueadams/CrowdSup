using CrowdSup.Api.Models.Responses.Usuarios;
using CrowdSup.Domain.Entities.Usuarios;

namespace CrowdSup.Api.Models.Mappers.Usuarios
{
    public class UsuarioResponseMapper
    {
        public static UsuarioResponse Map(Usuario usuario)
        {
            if (usuario is null)
                return default;

            return new UsuarioResponse(usuario.Id, usuario.Nome, usuario.FotoPerfil, usuario.DataNascimento, usuario.Cidade,
                usuario.Estado, usuario.Telefone, usuario.Sexo);
        }
    }
}