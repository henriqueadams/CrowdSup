using CrowdSup.Infra.CrossCutting.Enums;

namespace CrowdSup.Api.Models.Responses.Usuarios
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public ETipoSexo Sexo { get; set; }

        public UsuarioResponse(
            int id,
            string nome,
            DateTime dataNascimento,
            string cidade,
            string estado,
            string telefone,
            ETipoSexo sexo
        )
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cidade = cidade;
            Estado = estado;
            Telefone = telefone;
            Sexo = sexo;
        }
    }
}