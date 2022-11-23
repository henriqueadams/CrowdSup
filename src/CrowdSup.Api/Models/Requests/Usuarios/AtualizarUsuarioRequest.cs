namespace CrowdSup.Api.Models.Requests.Usuarios
{
    public class AtualizarUsuarioRequest
    {
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
    }
}