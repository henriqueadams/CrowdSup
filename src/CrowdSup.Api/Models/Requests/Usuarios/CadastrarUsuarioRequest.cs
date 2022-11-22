using CrowdSup.Infra.CrossCutting.Enums;

namespace CrowdSup.Api.Models.Requests.Usuarios
{
    public class CadastrarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public ETipoSexo Sexo { get; set; }
    }
}