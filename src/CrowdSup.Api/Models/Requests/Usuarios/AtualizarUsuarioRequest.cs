namespace CrowdSup.Api.Models.Requests.Usuarios
{
    public class AtualizarUsuarioRequest
    {
        public string FotoPerfil { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
    }
}