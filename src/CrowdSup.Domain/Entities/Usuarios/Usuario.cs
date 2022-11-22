using CrowdSup.Infra.CrossCutting.Enums;

namespace CrowdSup.Domain.Entities.Usuarios
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Telefone { get; private set; }
        public ETipoSexo Sexo { get; private set; }

        private Usuario() { }

        public Usuario(
            string nome,
            string email,
            string senha,
            DateTime dataNascimento,
            string cidade,
            string estado,
            string telefone,
            ETipoSexo sexo
        )
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Cidade = cidade;
            Estado = estado;
            Telefone = telefone;
            Sexo = sexo;
        }
    }
}